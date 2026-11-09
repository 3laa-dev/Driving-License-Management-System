using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    internal class clsUtil
    {
        static string generateGUID() {
            Guid guid = Guid.NewGuid();
            return guid.ToString() ;
        }

        static bool CreateFolderIfDoesNotExist(string DestinationFolder) {
            if (Directory.Exists(DestinationFolder))
            {
                return true;
            }
            try
            {
                Directory.CreateDirectory(DestinationFolder);
            }
            catch (Exception ex) { 
                return false;   
            }
            return true;
        }

        static string ReplaceFileNameWithGuid(string FileName) { 
            string guid = generateGUID();
            FileInfo fileInfo = new FileInfo(FileName);
            string ext = fileInfo.Extension;
            
            return guid + ext;
        }
        public static bool CopyImageToProjectImagesFolder(ref string FileSource) {

            string DestinationFolder = @"C:\DVLD-People-Images\";
            if (CreateFolderIfDoesNotExist(DestinationFolder))
            {
                string NewFileSource = DestinationFolder + ReplaceFileNameWithGuid(FileSource);
                try
                {
                    File.Copy(FileSource, NewFileSource);
                    FileSource = NewFileSource;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error if image saving");
                    return false;
                }
            }

            
            return true;
        }
    }
}
