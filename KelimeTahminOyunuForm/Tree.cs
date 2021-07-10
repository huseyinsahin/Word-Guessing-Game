using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace KelimeTahminOyunuForm
{
    class TreeNode
    {
        private string str;
        private int length;
        private List<int> points;
        private List<TreeNode> child;
        private int word_left;

        public int _word_left
        {
            get
            {
                return this.word_left;
            }
            set
            {
                this.word_left = value;
            }
        }
        public string str_
        {
            get
            {
                return this.str;
            }
            set
            {
                this.str = value;
                this.length = str.Length;
            }
        }

        public int find(int p)
        {
            return points.IndexOf(p);
        }
        public void push(int p)
        {
            points.Add(p);
        }
        public TreeNode getChild(int p)
        {
            int i = find(p);
            if (i != -1)
            {
                return child[i];
            }
            return null;
        }
        public void setChild(int i, TreeNode node)
        {
            this.push(i);
            i = find(i);
            if (i >= 0)
                this.child.Add(node);
        }
        public int length_
        {
            get
            {
                return this.length;
            }
            private set
            {
                this.length = value;
            }
        }
        public TreeNode()
        {
            str = "";
            length = 0;
            child = new List<TreeNode>();
            points = new List<int>();
            word_left = 1;
        }

    }
    class Tree
    {
        List<string> dictionary;
        TreeNode root;
        string path;
        bool kP;
        int n;
        Form1 frm;
        public Tree(Form1 f)
        {
            frm = f;
        }
        public void open_dictionary()
        {
            try
            {
                StreamReader sr = new StreamReader(this.path);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line == "")
                    {
                        continue;
                    }
                    //if (this.dictionary.IndexOf(line) == -1)
                        this.dictionary.Add(line);
                }
                sr.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Sözlük dosya hatası!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                frm.btnDurdur_Click(this, new EventArgs());
            }
        }

        public bool is_there(string word)
        {
            return (this.dictionary.IndexOf(word) != -1) ;
        }
        public void game_(string path)
        {
            this.path = path;
            this.dictionary = new List<string>();
            

            open_dictionary();

            this.n = dictionary.Count;
        }
        public bool addNode(string s)
        {
            bool add_complete = false;
            TreeNode newNode = new TreeNode();
            newNode.str_ = s;
            if (root == null)
            {
                root = newNode;
                n++;
                return true;
            }
            else
            {
                TreeNode v = new TreeNode();
                v = root;
                int point;
                while (!add_complete)
                {
                    if (!kP)
                        point = nPoint(v, newNode);
                    else
                        point = kPoint(v, newNode);
                    if (v.getChild(point) != null)
                    {
                        v._word_left++;
                        v = v.getChild(point);
                        continue;
                    }
                    else
                    {
                        v.setChild(point, newNode);
                        v._word_left++;
                        n++;
                        add_complete = true;
                    }
                }
            }
            return false;
        }
        public int nPoint(TreeNode parent, TreeNode child)
        {
            string letters = get_letters(child);
            int n_point = 0;
            for (int i = 0; i < letters.Length; i++)
            {
                for (int j = 0; j < parent.length_; j++)
                {
                    if (letters[i] == parent.str_[j])
                        n_point++;
                    else
                        continue;
                }
            }
            return n_point;
        }

        public int kPoint(TreeNode parent, TreeNode child)
        {

            int k_point = 0;
            for (int i = 0; i < child.length_; i++)
            {
                for (int j = 0; j < parent.length_; j++)
                {
                    if (child.str_[i] == parent.str_[j])
                        k_point++;
                    else
                        continue;
                }
            }
            return k_point;
        }
        private string get_letters(TreeNode node)
        {
            string list = "";
            for (int i = 0; i < node.length_; i++)
            {
                if (is_on_list(node.str_[i], list))
                    continue;
                else
                    list += node.str_[i];

            }
            return list;
        }
        private bool is_on_list(char letter, string list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] == letter) return true;
                else continue;
            }
            return false;
        }
        public string getRandomWord()
        {
            Random rnd = new Random();
            int randVal = rnd.Next(0,this.n);
            //2. oyun başladığında dizi dışına çıkıyor
            return dictionary[randVal];
        }
        public void add_to_dict(string word_to_add)
        {
            FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("");
            sw.Write(word_to_add);
            sw.Flush();
            sw.Close();
            fs.Close();
        }
        public TreeNode getRoot()
        {
            return root;
        }

        public void game_init(string path, bool kP)
        {
            this.path = path;
            this.kP = kP;
            this.dictionary = new List<string>();

            open_dictionary();
            frm.load_bar_setMax(dictionary.Count);
            frm.load_bar_visibility(true);
            dictionary.Sort((a, b) => b.Length.CompareTo(a.Length));

            foreach (string item in dictionary)
            {
                addNode(item);
                frm.load_bar_incValue(1);
            }
            frm.load_bar_visibility(false);
            frm.load_bar_resetVal();
            
        }
    }
}
