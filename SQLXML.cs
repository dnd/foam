using System;
using System.Collections;
using System.Xml;
using System.IO;
using System.Text;

namespace DND
{
	/// <summary>
	/// Summary description for SQLXML.
	/// </summary>
	public class SQLXML
	{
		private string m_ProcName = "";
		private Hashtable m_Levels;
		private ArrayList m_NodeList;
		private Hashtable m_NodeOrder;
		private XmlDocument m_XMLDoc;

		private Hashtable m_Params;
		private Hashtable m_Constraints;
		private Hashtable m_OrderBy;
		private ArrayList m_ParamsOrder;
		private ArrayList m_ConstraintsOrder;
		private ArrayList m_OrderByOrder;

		private string cr = "\r\n";

		public SQLXML(string ProcName) {
			m_ProcName = ProcName;
			m_Constraints = new Hashtable();
			m_OrderBy = new Hashtable();
			m_Params = new Hashtable();
			m_ConstraintsOrder = new ArrayList();
			m_OrderByOrder = new ArrayList();
			m_ParamsOrder = new ArrayList();
		}

		public string LoadXML(XmlDocument doc) {
			//Set the member to the passed in doc
			try {
				m_XMLDoc = doc;
				return "";
			} catch {
				return "Could not parse the requested XML document. The document was not properly formatted.";
			}
		}

		public string LoadXML(string DocumentPath) {
			try {
				m_XMLDoc = new XmlDocument();
				m_XMLDoc.Load(DocumentPath);
				return "";
			} catch (Exception e) {
				return "Could not parse the requested XML document. The document was not properly formatted.";
			}
		}

		public bool Parse() {
			m_Levels = new Hashtable();
			m_NodeList = new ArrayList();
			m_NodeOrder = new Hashtable();

			int StartLevel = 0;
			return ParseStructure(m_XMLDoc, "", ref StartLevel);
		}

		private bool ParseStructure(XmlNode StartNode, string CurrentParent, ref int CurrentLevel) {
			
			bool CheckedAttributes = false;
			int NewLevel = CurrentLevel;
			//string CurrentParent = "";
			string tmpParent = "";

			try {
				foreach(XmlNode node in StartNode) {
					bool HasChildren = false;
					bool HasAttributes = false;
										
					//NOTE: This is a workaround because checking for HasChildNodes always yields true!
					//TODO: Figure out what is the correct solution to this problem.
					//Check for child nodes.
					if (node.HasChildNodes) {
						if (node.FirstChild.Name != "#text") {
							HasChildren = true;
						}
					}

					//Check for attributes
					if (node.Attributes.Count > 0 )
						HasAttributes = true;

					//Check for a parent node
					try {
						string s = "";
						if (node.Name == "Image")
							s = "";

						if (tmpParent.Length < 1)
							tmpParent = (CurrentParent.Length > 0?CurrentParent + "." + node.ParentNode.Name:node.ParentNode.Name);

						//Check if we still have the same parent
						if (CurrentParent != tmpParent) {
							//Check if we have a new parent
							if (!m_Levels.ContainsKey(tmpParent)) {
								//Add the new level
								m_Levels.Add(tmpParent, NewLevel);

								NewLevel++;
								CurrentLevel = NewLevel;

								//Special circumstance for many to one tags.
								if (!HasChildren && HasAttributes) {
									if(!m_Levels.ContainsKey(tmpParent + "." + node.Name))
										m_Levels.Add(tmpParent + "." + node.Name, NewLevel);
								}
							} else {
								CurrentLevel = ((int)m_Levels[tmpParent]) + 1;
							}
						}
						CurrentParent = tmpParent;
	
					} catch {
						CurrentParent = "#document";
						CurrentLevel = 1;
					}

					//if there's no child nodes then assume that it is an element.
					if (HasChildren) {
						if (HasAttributes) {
							//Run through the attributes that this node may have.
							foreach (XmlAttribute attb in node.Attributes) {
								//Add the attribute to the list
								m_NodeOrder.Add(CurrentParent + "." + node.Name + "." + attb.Name, m_NodeList.Add(new SQLNode(attb.Name, node.Name, CurrentParent + "." + node.Name, CurrentLevel, false, attb.Value)));
							}
						} else {
							//Special circumstance for a tag with children, but no attributes or single elements.
							m_NodeOrder.Add(CurrentParent + "." + node.Name, m_NodeList.Add(new SQLNode("", node.Name, CurrentParent, CurrentLevel, false, "NULL")));
						}

						//Don't add attributes twice.
						CheckedAttributes = true;

						//Recurse to walk through the children of this node.
						ParseStructure(node, CurrentParent, ref CurrentLevel);
					} else {
						string val = (node.InnerText == null?"":node.InnerText);
						//Only add the element if there is a value
						if (val.Length > 0) {
							//Find the correct level by adding 1 to the parent's level
							int tmpLevel = ((int)m_Levels[tmpParent]) + 1;
							//Add the node as an element
							m_NodeOrder.Add(CurrentParent + "." + node.Name, m_NodeList.Add(new SQLNode(node.Name, node.ParentNode.Name, CurrentParent, tmpLevel, true, node.InnerText)));
						}
					}

					//Make sure that we haven't already checked for attributes
					if (!CheckedAttributes && HasAttributes) {
						//Run through the attributes that this node may have.
						foreach (XmlAttribute attb in node.Attributes) {
							//Add the attribute to the list
							m_NodeOrder.Add(CurrentParent + "." + node.Name + "." + attb.Name, m_NodeList.Add(new SQLNode(attb.Name, node.Name, CurrentParent + "." + node.Name, CurrentLevel, false, attb.Value)));
						}
						CurrentLevel++;
					}
				}
				return true;
			} catch (Exception e) {
				return false;
			}
		}

		public string BuildQuery() {
			int MaxLevel = 1;
			string sp = "";
			Hashtable Tags = new Hashtable();

			sp = "/********************************************" + cr;
			sp += "* Output produced by Foam @ " + cr;
			sp += "*\t" + DateTime.Now + cr;
			sp += "*" + cr;
			sp += "* digital nothing design " + cr;
			sp += "* http://www.digitalnothing.com" + cr;
			sp += "********************************************/" + cr + cr;

			sp += ("CREATE PROCEDURE " + m_ProcName + cr);
	
			//Check for parameters
			if (m_Params.Count > 0) {
				sp += "\t(" + cr;
				//RUn through and append the list of parameters
				for (int n = 0; n < m_ParamsOrder.Count; n++) {
					sp += "\t" + ((string)m_ParamsOrder[n] + " " + (string)m_Params[m_ParamsOrder[n]] + "," + cr);
				}
				//Remove trailing comma 
				sp = (sp.Substring(0, sp.Length - 3) + cr);
				sp += "\t)" + cr;
			}

			sp += "AS" + cr + cr;

			sp += "SET NOCOUNT ON " + cr + cr;
			
			for (int CurrentLevel = 1; CurrentLevel <= MaxLevel; CurrentLevel++) {
				string CurrentPath = "";

				//Append SELECT header
				for (int i = 0; i < m_NodeList.Count; i++) {
					SQLNode node = (SQLNode)m_NodeList[i];
					if (node.Level == CurrentLevel) {
						//Retrieve the parent node, so we can get the parent's parent level.
						string ParentPath = node.FullPath;
						ParentPath = (node.Name == ""?ParentPath:ParentPath.Substring(0, node.FullPath.LastIndexOf(".")));
						//Get the current path for the block.
						//This is used for determining where to attach constraints.
						CurrentPath = node.FullPath.Replace("#document.", "") + (m_Levels.ContainsKey(node.FullPath + "." + (node.Name == ""?node.Parent:node.Name))?"." + (node.Name == ""?node.Parent:node.Name):"");

						int ParentLevel = (int)m_Levels[ParentPath];
						ParentLevel = (ParentLevel < 1?1:ParentLevel);
						sp += ("SELECT Tag = " + CurrentLevel.ToString() + ", Parent = " + ((CurrentLevel == 1)?"NULL":ParentLevel.ToString()) + "," + cr);
						break;
					}
				}
				

				for(int n = 0; n < m_NodeList.Count; n++) {
					SQLNode node = (SQLNode)m_NodeList[n];

					//Check for a new max level to loop through.
					MaxLevel = (node.Level > MaxLevel?node.Level:MaxLevel);	

					//Append the node format info
					sp += ("\t[" + node.Parent + "!" + node.Level.ToString() + "!" + node.Name + (node.Element?"!element":"") + "] = ");
					
					//Add the official tag to the hash for later use.
					if (!Tags.ContainsKey((node.FullPath + "." + node.Name)))
						Tags.Add((node.FullPath + "." + node.Name), ("[" + node.Parent + "!" + node.Level.ToString() + "!" + node.Name + (node.Element?"!element":"") + "]"));

					//Append the proper value to the node.
					//If we're not on the same level, then we need to append NULL as a placeholder.
					if (node.Level == CurrentLevel || m_OrderBy.ContainsKey(node.FullPath.Replace("#document.", "") + "." + node.Name)) {
						sp += (node.Value + "," + cr);
					} else {
						sp += ("NULL," + cr);
					}
				}
				//Remove the trailing comma
				sp = (sp.Substring(0, sp.Length - 3) + cr);
	
				//Check if there is a FROM/WHERE clause for this level
				if (m_Constraints.ContainsKey(CurrentPath))
					sp += m_Constraints[CurrentPath] + cr;

				//Check if we have more UNIONs
				if (CurrentLevel != MaxLevel) {
					sp += cr + "UNION ALL" + cr + cr;
				} else {
					//Check for any ORDER BY requirements
					if (m_OrderBy.Count > 0) {
						sp += cr + "ORDER BY" + cr;
						//Run through the requests ORDER BYs
						for (int n = 0; n < m_OrderByOrder.Count; n++) {
							//Make sure to reappend the root level tag
							sp += ("\t" + Tags["#document." + (string)m_OrderByOrder[n]] + " " + (string)m_OrderBy[m_OrderByOrder[n]] + "," + cr);
						}
						//Remove the trailing comma
						sp += "\tTag" + cr;
					}
					//Add the final piece.
					sp += cr + "FOR XML EXPLICIT";
				}
			}
			//Send back the hopefully complete procedure.
			return sp;
		}

		public ArrayList Nodes {
			get {
				return m_NodeList;
			}
		}

		public Hashtable NodeOrder {
			get {
				return m_NodeOrder;
			}
		}
		
		public Hashtable Levels {
			get {
				return m_Levels;
			}
		}

		public SQLNode Node(string NodeName) {
			return (SQLNode)m_NodeList[(int)m_NodeOrder[NodeName]];
		}

		public string ProcedureName {
			get {
				return m_ProcName;
			}
			set {
				m_ProcName = value;
			}
		}

		public Hashtable Parameters {
			set {
				m_Params = value;
			}
		}
		
		public Hashtable Constraints {
			set {
				m_Constraints = value;
			}
		}
		
		public Hashtable OrderBy {
			set {
				m_OrderBy = value;
			}
		}

		public ArrayList ParametersOrder {
			set {
				m_ParamsOrder = value;
			}
		}
		
		public ArrayList ConstraintsOrder {
			set {
				m_ConstraintsOrder = value;
			}
		}
		
		public ArrayList OrderByOrder {
			set {
				m_OrderByOrder = value;
			}
		}

	}

	public  struct SQLNode {
		public bool Element;
		public int Level;
		public string Parent;
		public string FullPath;
		public string Name;
		public string Value;

		public SQLNode(string name, string parent, string fullPath, int level, bool element, string val) {
			Name = name;
			Parent = parent;
			FullPath = fullPath;
			Element = element;
			Level = level;
			Value = val;

			if (Element) Level--;
		}
	}
}
