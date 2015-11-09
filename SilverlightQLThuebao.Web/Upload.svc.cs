using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace SilverlightQLThuebao.Web
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Upload
    {
        [OperationContract]
        public UploadFile DoUpload(string filename, byte[] content, bool append, string foldertemp)
        {
            string folder = Path.GetFullPath(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "FileStore/" + foldertemp));
            if (!System.IO.Directory.Exists(folder))
                System.IO.Directory.CreateDirectory(folder);


            FileMode m = FileMode.Create;
            if (append)
                m = FileMode.Append;

            using (FileStream fs = new FileStream(folder + @"\" + filename, m, FileAccess.Write))
            {
                fs.Write(content, 0, content.Length);
                fs.Close();
                fs.Dispose();
            }

            UploadFile file = new UploadFile { Name = filename, FileStoreUrl = "../FileStore/" + foldertemp + "/" + filename };
            return file;
        }

        //public UploadFile DoDownload(string filename, byte[] content, bool append)
        //{
        //    string folder = Path.GetFullPath(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "FileStore"));
        //    if (!System.IO.File.Exists(folder + @"\" + filename))
        //    {
        //        using (FileStream fs = new FileStream(folder + @"\" + filename, m, FileAccess.Read))
        //        {
        //            fs.Read(content, 0, content.Length);
        //        }

        //        UploadFile file = new UploadFile { Name = filename, FileStoreUrl = "../FileStore/" + filename };
        //        return content;
        //    }

        //}
        [OperationContract]
        public PictureFile Download(string pictureName)
        {
            FileStream fileStream = null;
            BinaryReader reader = null;
            string imagePath;
            byte[] imageBytes;

            string folder = Path.GetFullPath(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "FileStore"));
            imagePath = folder + @"\" + pictureName;
            if (File.Exists(imagePath))
            {

                fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
                reader = new BinaryReader(fileStream);
                imageBytes = reader.ReadBytes((int)fileStream.Length);
                fileStream.Dispose();
                fileStream.Close();
                return new PictureFile() { PictureName = pictureName, PictureStream = imageBytes };
            }
            return null;
        }

        [OperationContract]
        public PictureFile Rename(string pictureName, string filename, string ffolder, string subf)
        {
            string imagePath, imageDes;

            string folder = Path.GetFullPath(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "FileStore"));
            imagePath = folder + @"\" + ffolder + @"\" + pictureName.ToUpper();
            if (subf == "")
                imageDes = folder + @"\" + filename.ToUpper();
            else
            {
                if (!System.IO.Directory.Exists(folder + @"\" + subf))
                    System.IO.Directory.CreateDirectory(folder + @"\" + subf);
                imageDes = folder + @"\" + subf + @"\" + filename.ToUpper();
            }

            if (imagePath != imageDes)
            {
                if (File.Exists(imagePath))
                {
                    if (File.Exists(imageDes))
                    {
                        File.Delete(imageDes);
                    }
                    File.Move(imagePath, imageDes);
                }
            }
            return null;
        }

        [OperationContract]
        public PictureFile DeleFolder(string subf)
        {
            string folder = Path.GetFullPath(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "FileStore/" + subf));

            if (System.IO.Directory.Exists(folder))
                System.IO.Directory.Delete(folder, true);

            return null;
        }


        [OperationContract]
        public PictureFile DeleFile(string filename)
        {
            string folder = Path.GetFullPath(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "FileStore"));
            string file = folder + @"\" + filename;
            if (File.Exists(file))
                File.Delete(file);

            return null;
        }

        [OperationContract]
        public DateTime GetDateTime()
        {           
            return DateTime.Now;
        }

        [OperationContract]
        public int GetSessionTimeOut()
        {
            return HttpContext.Current.Session.Timeout;
        }

        [OperationContract]
        public string DoWork()
        {
            OperationContext operationContext = OperationContext.Current;

            MessageProperties messageProperties = operationContext.IncomingMessageProperties;

            RemoteEndpointMessageProperty remoteEndpointProperty = messageProperties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;

            string strIPAddress = remoteEndpointProperty.Address;

            if (strIPAddress == "::1")
            {
                strIPAddress = "127.0.0.1";
            }
            return strIPAddress;           
        }


    }

    [DataContract]
    public class UploadFile
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string FileStoreUrl { get; set; }
    }


    [DataContract]
    public class PictureFile
    {
        [DataMember]
        public string PictureName { get; set; }
        [DataMember]
        public byte[] PictureStream { get; set; }
    }
}
