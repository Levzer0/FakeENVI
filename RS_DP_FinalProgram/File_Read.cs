using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RS_DP_FinalProgram
{
    //遥感数字图像文件读写类
    class File_Read
    {
        public string Path;
        //读取.hdr文件获取图像的编码方式和大小
        public void read_HDR()
        {
            StreamReader sr = new StreamReader(Path);
            
        }

    }
}
