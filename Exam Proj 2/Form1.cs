using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam_Proj_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(Directory.GetCurrentDirectory().ToString());
        }

        private void BtnGo_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(Directory.GetCurrentDirectory().ToString() + "\\Data1.txt") &&
                System.IO.File.Exists(Directory.GetCurrentDirectory().ToString() + "\\Data2.txt"))
            {
                redOut.AppendText("Data1.txt exist and Data2.txt exist!");
            }
            else
            {
                if (System.IO.File.Exists(Directory.GetCurrentDirectory().ToString() + "\\Data1.txt"))
                {
                    redOut.AppendText("Only Data1.txt exists");
                    try
                    {
                        FileInfo fi = new FileInfo(Directory.GetCurrentDirectory().ToString() + "\\Data2.txt");

                        long fileSize = fi.Length;

                        File.Create(fi.ToString());

                        redOut.AppendText("Data2.txt Created");
                    }
                    catch (Exception err)
                    {
                        redOut.AppendText(err.ToString());
                    }
                }
                else if (System.IO.File.Exists(Directory.GetCurrentDirectory().ToString() + "\\Data2.txt"))
                {
                    redOut.AppendText("Only Data1.txt exists");
                    try
                    {
                        FileInfo fi = new FileInfo(Directory.GetCurrentDirectory().ToString() + "\\Data1.txt");

                        long fileSize = fi.Length;

                        File.Create(fi.ToString());

                        redOut.AppendText("Data1.txt Created");
                    }
                    catch (Exception err)
                    {
                        redOut.AppendText(err.ToString());
                    }
                }
                else
                {
                    redOut.AppendText("Neither Data1.txt nor Data2.txt Exist");
                    try
                    {
                        FileInfo fi = new FileInfo(Directory.GetCurrentDirectory().ToString() + "\\Data1.txt");
                        FileInfo fi2 = new FileInfo(Directory.GetCurrentDirectory().ToString() + "\\Data2.txt");

                        long fileSize = fi.Length;
                        long fileSize2 = fi2.Length;

                        File.Create(fi.ToString());
                        File.Create(fi2.ToString());

                        redOut.AppendText("Data1.txt Created");
                        redOut.AppendText("Data2.txt Created");
                    }
                    catch (Exception err)
                    {
                        redOut.AppendText(err.ToString());
                    }
                }
            }

            using (Stream str = new FileStream(Directory.GetCurrentDirectory().ToString() + "\\Data1.txt", FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(str))
                {
                    string words = "nimble yielding far-flung giddy cut eight vulgar degree calculating treatment yell lavish flower fact extra-small rambunctious oranges pleasure yoke judicious disgusting bag number allow dam responsible request toothpaste long lamp tame land beds clean curved great reply type step grubby preach whirl elastic loose moor error macabre ignorant humorous amuse walk meeting dime playground lewd furtive straight bat tail engine forgetful instrument name race kill punch closed discover dear feeling greasy tug shrug cracker spotty drawer hushed develop voiceless iron smell capricious trousers illustrious miniature hall married shock embarrass dress sisters scale diligent nerve spotless slimy clear zesty wine board pat pretend holiday lunchroom zany determined anger secretive achiever table sleepy scattered pen believe smash careless groan travel horn reduce shocking festive toad suppose quicksand grey plain profit foot crazy intelligent questionable slow scribble zephyr hammer rigid false club far start possess story excellent crib periodic correct innocent unique crawl texture expansion room wise nest flat girl clammy record apathetic use sniff point thundering decide terrify education intend carpenter stir bat satisfy certain form group wide-eyed fang untidy legal brake better post grip wide hand suffer color like geese channel sneaky creature muddled smiling wrong jumbled hideous bridge damaged alluring";
                    writer.WriteLine(words);
                }
            }

            using (Stream str = new FileStream(Directory.GetCurrentDirectory().ToString() + "\\Data2.txt", FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(str))
                {
                    string words = "smelly slimy prickly knit third activity attach embarrass dispensable instinctive subtract youthful sweet spray smart quarter shoe mute whistle willing few skirt tearful engine decorous cut undesirable smiling noxious program terrify zany tangible splendid greasy lake mushy clear talented cherry rush tacit remember color cool dog freezing sigh admit burn twig test handy order deranged horses baseball boring mask calculate name battle guarantee pollution homely match attempt protective boat harbor guide ask channel melodic shame squeeze story act cute straw interrupt lazy neck paddle far spicy person reflect complex hate ice trot frightening table listen separate bite-sized gleaming hurt blue";
                    writer.WriteLine(words);
                }
            }

            string word1 = tbxWord.Text;

            using (Stream str = new FileStream(Directory.GetCurrentDirectory().ToString() + "\\Data1.txt", FileMode.Create, FileAccess.ReadWrite))
            {
                using (StreamReader reader = new StreamReader(str))
                {
                    using (Stream str2 = new FileStream(Directory.GetCurrentDirectory().ToString() + "\\Data2.txt", FileMode.Create, FileAccess.ReadWrite))
                    {
                        using (StreamReader reader2 = new StreamReader(str2))
                        {
                            try
                            {
                                string data1list = reader.ReadLine();
                                string[] data1 = data1list.Split(' ');
                                string data2list = reader2.ReadLine();
                                string[] data2 = data2list.Split(' ');

                                /*FileInfo fi = new FileInfo(Directory.GetCurrentDirectory().ToString() + "\\Data3.txt");

                                long fileSize = fi.Length;

                                File.Create(fi.ToString());*/

                                using (Stream str3 = new FileStream(Directory.GetCurrentDirectory().ToString() + "\\Data3.txt", FileMode.Create, FileAccess.Write))
                                {
                                    using (StreamWriter writer2 = new StreamWriter(str3))
                                    {
                                        FileSecurity fSecurity = File.GetAccessControl(Directory.GetCurrentDirectory().ToString() + "\\Data3.txt");
                                        fSecurity.AddAccessRule(new FileSystemAccessRule("everyone", FileSystemRights.ReadAndExecute, AccessControlType.Deny));
                                        File.SetAccessControl(Directory.GetCurrentDirectory().ToString() + "\\Data3.txt", fSecurity);
                                        if (data1.Length > data2.Length)
                                            for (int i = 0; i <= data1.Length; i++)
                                            {
                                                if (data2.Length > i)
                                                {
                                                    writer2.WriteLine(data1[i] + word1 + data2[i]);
                                                }
                                                else
                                                {
                                                    writer2.WriteLine(data1[i] + word1);
                                                }
                                            }
                                        else
                                        {
                                            for (int i = 0; i <= data2.Length; i++)
                                            {
                                                if (data1.Length > i)
                                                {
                                                    writer2.WriteLine(data1[i] + word1 + data2[i]);
                                                }
                                                else
                                                {
                                                    writer2.WriteLine(data2[i] + word1);
                                                }
                                            }
                                        }
                                        fSecurity = File.GetAccessControl(Directory.GetCurrentDirectory().ToString() + "\\Data3.txt");
                                        fSecurity.AddAccessRule(new FileSystemAccessRule("everyone", FileSystemRights.FullControl, AccessControlType.Deny));
                                        File.SetAccessControl(Directory.GetCurrentDirectory().ToString() + "\\Data3.txt", fSecurity);
                                    }
                                }
                            }catch(Exception err)
                            {
                                MessageBox.Show(err.ToString());
                            }
                        }
                    }
                }
            }
        }
    }
}
