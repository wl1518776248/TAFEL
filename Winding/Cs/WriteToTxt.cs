using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Winding.Cs
{
    public class WriteToTxt
    {
        ~WriteToTxt()
        { }
        string deletePath = string.Empty;
        string[] fileFullPath = new string[12];
        public void WriteValueToTxt(string currently, string path, string title, string value)
        {
            try
            {
                if (!Directory.Exists(currently))
                {
                    Directory.CreateDirectory(currently);
                }
                if (!File.Exists(currently + path))
                {
                    using (FileStream fsWrite = new FileStream(currently + path, FileMode.Append, FileAccess.Write))
                    {
                        byte[] buffer1 = Encoding.Default.GetBytes(title + value);
                        fsWrite.Write(buffer1, 0, buffer1.Length);
                    }
                }
                else
                {
                    using (FileStream fsWrite = new FileStream(currently + path, FileMode.Append, FileAccess.Write))
                    {
                        byte[] buffer1 = Encoding.Default.GetBytes(value);
                        fsWrite.Write(buffer1, 0, buffer1.Length);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public string ReadTxt(string path)
        {
            try
            {
                using (FileStream fsRead = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    byte[] buffer = new byte[1024 * 1024 * 5];
                    int length = fsRead.Read(buffer, 0, buffer.Length);
                    string str = Encoding.UTF8.GetString(buffer, 0, length);
                    return str;
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }

        }

        public void DeleteFile(string path)
        {
            try
            {
                if (DateTime.Now.Month == 1)
                {
                    deletePath = path + (DateTime.Now.Year - 1).ToString() + @"-11\";
                }
                else if (DateTime.Now.Month == 2)
                {
                    deletePath = path + (DateTime.Now.Year - 1).ToString() + @"-12\";
                }
                else
                {
                    deletePath = path + DateTime.Now.Year.ToString() + "-" + (DateTime.Now.Month - 2).ToString() + @"\";
                }
                fileFullPath = Directory.GetDirectories(path);
                for (int i = 0; i < fileFullPath.Length; i++)
                {
                    if (fileFullPath[i] == deletePath.Substring(0, deletePath.Length - 1))
                    {
                        DirectoryInfo deleteFile = new DirectoryInfo(fileFullPath[i]);
                        deleteFile.Delete(true);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public void CopyFile(string copyPath, string path)
        {
            if (!Directory.Exists(copyPath))
            {
                File.Copy(copyPath, path);
            }
        }

        public void CloseFile(string name)
        {
            Process[] pro = Process.GetProcesses();
            for (int i = 0; i < pro.Length; i++)
            {
                if (pro[i].MainWindowTitle.ToString() == Cs.GlobalVariable.processName + name)//name+ " - Excel" ) 
                {
                    pro[i].Kill();//结束进程
                }
            }

        }


    }
}
