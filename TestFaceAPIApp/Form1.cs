using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using System.IO;

namespace TestFaceAPIApp
{
    public partial class Form1 : Form
    {
        private readonly IFaceServiceClient faceServiceClient = new FaceServiceClient("5d017c9a97c745c6a1e45c2a8edaec95", "https://southcentralus.api.cognitive.microsoft.com/face/v1.0");
  
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async Task<Face[]> UploadAndDetectFaces(string imageFilePath)
        {
            try
            {
                using (Stream imageFileStream = File.OpenRead(imageFilePath))
                {
                    var faces = await faceServiceClient.DetectAsync(imageFileStream,
                        true,
                        true,
                        new FaceAttributeType[] {
                    FaceAttributeType.Gender,
                    FaceAttributeType.Age,
                    FaceAttributeType.Emotion
                        });
                    return faces.ToArray();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new Face[0];
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Face[] faces = await UploadAndDetectFaces("C:\\FaceAPI\\FaceAPI\\Images\\download.jpg");
        }
    }
}
