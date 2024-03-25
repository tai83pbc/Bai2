using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bai2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txt_Path.Text = openFileDialog.FileName;
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(txt_Path.Text);
                TV_xml.Nodes.Clear(); // Xóa các node hiện có trong TreeView

                XmlNodeList childNodes = xmlDocument.DocumentElement.ChildNodes;
                foreach (XmlNode childNode in childNodes)
                {
                    LoadTreeViewNodesFromXml(childNode, TV_xml.Nodes);
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn File");
            }
        }

        private void LoadTreeViewNodesFromXml(XmlNode parentNode, TreeNodeCollection treeNodeCollection)
        {
            if (parentNode.NodeType == XmlNodeType.Element)
            {
                XmlElement element = (XmlElement)parentNode;
                string elementName = element.Name;
                string elementAttributes = GetAttributesAsString(element);

                TreeNode treeNode = new TreeNode("Node: " + elementName);
                if (!string.IsNullOrEmpty(elementAttributes))
                {
                    treeNode.Text += " " + elementAttributes;
                }

                TreeNodeData treeNodeData = new TreeNodeData();
                treeNodeData.Text = elementName;
                treeNodeData.Attributes = GetAttributes(element);
                treeNode.Tag = treeNodeData;

                treeNodeCollection.Add(treeNode);

                if (parentNode.HasChildNodes)
                {
                    foreach (XmlNode childNode in parentNode.ChildNodes)
                    {
                        if (childNode.NodeType == XmlNodeType.Text)
                        {
                            string textContent = childNode.InnerText.Trim();
                            if (!string.IsNullOrEmpty(textContent))
                            {
                                TreeNode textNode = new TreeNode(textContent);
                                treeNode.Nodes.Add(textNode);
                            }
                        }
                        else if (childNode.NodeType == XmlNodeType.Element)
                        {
                            LoadTreeViewNodesFromXml(childNode, treeNode.Nodes);
                        }
                    }
                }
            }
        }
        private string GetAttributesAsString(XmlElement element)
        {
            StringBuilder attributesBuilder = new StringBuilder();

            foreach (XmlAttribute attribute in element.Attributes)
            {
                attributesBuilder.Append(attribute.Name);
                attributesBuilder.Append("=\"");
                attributesBuilder.Append(attribute.Value);
                attributesBuilder.Append("\" ");
            }

            return attributesBuilder.ToString().Trim();
        }

        private void TV_xml_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode clickedNode = TV_xml.GetNodeAt(e.X, e.Y); // Lấy nút tại vị trí chuột nhấn phải

                if (clickedNode != null || TV_xml.HitTest(e.X, e.Y).Location == TreeViewHitTestLocations.None)
                {
                    TV_xml.SelectedNode = clickedNode; // Chọn nút đó trong cây TreeView
                    contextMenuStrip1.Show(e.X + TV_xml.Location.X + Location.X, e.Y + TV_xml.Location.Y + Location.Y);
                }
            }
        }

        private void add_Node_Click(object sender, EventArgs e)
        {
            if (TV_xml.SelectedNode != null)
            {
                addNodeForm addnodeform = new addNodeForm();
                if (addnodeform.ShowDialog() == DialogResult.OK)
                {
                    TreeNode selectedNode = TV_xml.SelectedNode;
                    TreeNode newNode = new TreeNode("Node: " + addnodeform.text);
                    selectedNode.Nodes.Add(newNode);
                    selectedNode.Expand();
                }
            }
            else
            {
                addNodeForm addnodeform = new addNodeForm();
                if (addnodeform.ShowDialog() == DialogResult.OK)
                {
                    TreeNode newNode = new TreeNode("Node: " + addnodeform.text);
                    TV_xml.Nodes.Add(newNode);
                }
            }
        }

        private void delete_Node_Click(object sender, EventArgs e)
        {
            if (TV_xml.SelectedNode != null)
            {
                TreeNode selectedNode = TV_xml.SelectedNode;
                if (selectedNode.Parent != null)
                {
                    selectedNode.Parent.Nodes.Remove(selectedNode);
                }
                else
                {
                    TV_xml.Nodes.Remove(selectedNode);
                }
            }
            else
            {
                MessageBox.Show("chưa Chọn Node.");
            }
        }

        private void edit_Node_Click(object sender, EventArgs e)
        {
            if (TV_xml.SelectedNode != null)
            {
                addNodeForm addnodeform = new addNodeForm();
                if (addnodeform.ShowDialog() == DialogResult.OK)
                {
                    TV_xml.SelectedNode.Text = addnodeform.text;
                }
            }
            else
            {
                MessageBox.Show("chưa Chọn Node.");
            }
        }

        private void find_Node_Click(object sender, EventArgs e)
        {
            addNodeForm addnodeform = new addNodeForm();
            {
                if (addnodeform.ShowDialog() == DialogResult.OK)
                {
                    string searchTerm = addnodeform.text;
                    TreeNode node = FindNode(TV_xml.Nodes, searchTerm);

                    if (node != null)
                    {
                        MessageBox.Show(node.FullPath);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy Node: " + searchTerm);
                    }
                }
            }
        }

        private TreeNode FindNode(TreeNodeCollection nodes, string searchTerm)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Text.Equals(searchTerm, StringComparison.OrdinalIgnoreCase))
                {
                    return node;
                }

                TreeNode foundNode = FindNode(node.Nodes, searchTerm);
                if (foundNode != null)
                {
                    return foundNode;
                }
            }

            return null;
        }


        private void save_Node_Click(object sender, EventArgs e)
        {
            if (TV_xml.Nodes.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để lưu.");
                return;
            }

            if (string.IsNullOrEmpty(txt_Path.Text))
            {
                MessageBox.Show("Chưa chọn tệp tin để lưu.");
                return;
            }

            XmlDocument xmlDocument = new XmlDocument();

            // Kiểm tra xem tài liệu XML đã có root element hay chưa
            if (xmlDocument.DocumentElement == null)
            {
                // Tạo root element chỉ khi tài liệu chưa có root element
                XmlElement rootElement = xmlDocument.CreateElement("Root");
                xmlDocument.AppendChild(rootElement);
            }

            foreach (TreeNode node in TV_xml.Nodes)
            {
                XmlNode xmlNode = CreateXmlNodeFromTreeNode(xmlDocument, node);
                if (xmlNode != null)
                {
                    xmlDocument.DocumentElement.AppendChild(xmlNode);
                }
            }

            xmlDocument.Save(txt_Path.Text);
            MessageBox.Show("Dữ liệu đã được lưu thành công.");
        }
        public class TreeNodeData
        {
            public string Text { get; set; }
            public Dictionary<string, string> Attributes { get; set; }

            public TreeNodeData()
            {
                Attributes = new Dictionary<string, string>();
            }
        }

        private XmlNode CreateXmlNodeFromTreeNode(XmlDocument xmlDocument, TreeNode treeNode)
        {
            if (treeNode == null)
            {
                return null;
            }

            if (treeNode.Nodes.Count == 0)
            {
                if(treeNode.Text.Contains("Node: "))
                {
                    string elementName = RemoveInvalidCharacters(treeNode.Text.Replace("Node: ", ""));
                    XmlNode elementNode = xmlDocument.CreateElement(elementName);
                    return elementNode;
                }
                else
                {
                    XmlText textNode = xmlDocument.CreateTextNode(treeNode.Text);
                    return textNode;
                }
            }
            else
            {
                var treeNodeData = treeNode.Tag as TreeNodeData;
                if (treeNodeData == null)
                {
                    return null;
                }

                string elementName = RemoveInvalidCharacters(treeNodeData.Text);
                if (string.IsNullOrEmpty(elementName))
                {
                    return null;
                }

                XmlNode elementNode = xmlDocument.CreateElement(elementName);

                foreach (TreeNode childNode in treeNode.Nodes)
                {
                    XmlNode xmlNode = CreateXmlNodeFromTreeNode(xmlDocument, childNode);
                    if (xmlNode != null)
                    {
                        elementNode.AppendChild(xmlNode);
                    }
                }

                // Thêm các thuộc tính vào phần tử
                if (treeNodeData.Attributes != null)
                {
                    foreach (var attribute in treeNodeData.Attributes)
                    {
                        string attributeName = RemoveInvalidCharacters(attribute.Key);
                        string attributeValue = attribute.Value;

                        // Tạo thuộc tính và gán giá trị
                        XmlAttribute xmlAttribute = xmlDocument.CreateAttribute(attributeName);
                        xmlAttribute.Value = attributeValue;

                        // Thêm thuộc tính vào phần tử
                        elementNode.Attributes.Append(xmlAttribute);
                    }
                }

                return elementNode;
            }
        }

        private Dictionary<string, string> GetAttributes(XmlElement element)
        {
            Dictionary<string, string> attributes = new Dictionary<string, string>();

            foreach (XmlAttribute attribute in element.Attributes)
            {
                attributes[attribute.Name] = attribute.Value;
            }

            return attributes;
        }
        private string RemoveInvalidCharacters(string input)
        {
            char[] invalidChars = { ' ', ':', ';', '&', '<', '>', '"', '\'','*' };
            string output = input;

            foreach (char invalidChar in invalidChars)
            {
                output = output.Replace(invalidChar, '_');
            }

            output = output.Replace("=", string.Empty);

            return output;
        }
    }
}
