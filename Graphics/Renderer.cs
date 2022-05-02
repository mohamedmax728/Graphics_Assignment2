using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace Graphics
{
    class Renderer
    {
        Shader sh;
        uint vertexBufferID;
        public void Initialize()
        {
            string projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            sh = new Shader(projectPath + "\\Shaders\\SimpleVertexShader.vertexshader", projectPath + "\\Shaders\\SimpleFragmentShader.fragmentshader");
            Gl.glClearColor(1, 1, 1.0f, 1);
            float[] verts = { 
		
		        // 1-  Eyes			  point index
		        //-----
		        0.2f,  0.5f, 0.0f,     //0
		        0.4f,  0.5f, 0.0f,     //1

		        // 2 - body
		        //----------
		        0.3f, 0.8f, 0.0f,      //2
		        0.8f, -0.4f, 0.0f,     //3
		        -0.3f, -0.4f, 0.0f,    //4
			
		        // 3 - Arms
		        // right arm
		        0.51f, 0.3f, 0.0f,     //5
		        0.9f, -0.0f, 0.0f,     //6
		        0.8f, -0.2f, 0.0f,     //7
                 
		        //left arm
		        0.05f, 0.3f, 0.0f,     //8
		        -0.4f, 0.1f, 0.0f,     //9
		        -0.4f, 0.3f, 0.0f,     //10

		        // 4 - Fan
		        -0.4f, 0.3f, 0.0f,     //11    // fan center
		        -0.2f, 0.3f, 0.0f,     //12    // t1
		        -0.25f, 0.4f, 0.0f,    //13
		        -0.4f, 0.5f, 0.0f,     //14    // t2
		        -0.55f, 0.4f, 0.0f,    //15    // t3
		        -0.6f, 0.3f, 0.0f,     //16    // t4


		        // 5 - legs
		        // right leg
		        0.3f, -0.4f, 0.0f,    //17
		        0.2f, -0.7f, 0.0f,    //18
		        0.4f, -0.7f, 0.0f,    //19

		        // left leg
		        0.0f, -0.4f, 0.0f,    //20
		        0.1f, -0.7f, 0.0f,    //21
		        -0.1f, -0.7f, 0.0f,   //22

		        // 6 - Nose 
		        0.3f,  0.3f, 0.0f,    //23
		        0.28f,  0.15f, 0.0f,  //24
		        0.3f,  0.2f, 0.0f,    //25
		        0.32f,  0.15f, 0.0f,  //26


		        // 7 - Mouth
		        0.2f,  0.0f, 0.0f,    //27
		        0.4f, -0.1f, 0.0f,    //28
		        0.2f,  -0.1f, 0.0f,   //29
		        0.4f,  0.0f, 0.0f,    //30
            };
            vertexBufferID = GPU.GenerateBuffer(verts);
        }

        public void Draw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            sh.UseShader();
            Gl.glEnableVertexAttribArray(0);
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, vertexBufferID);
            Gl.glVertexAttribPointer(0, 3, Gl.GL_FLOAT, Gl.GL_FALSE, 0, IntPtr.Zero);

            //// Draw your primitives !
            //// 1-  Eyes        
            //glPointSize();
            //glDrawArrays();
            Gl.glDrawArrays(Gl.GL_LINE_LOOP, 0, 2);
            //// 2 - body
            //glDrawArrays();
            Gl.glDrawArrays(Gl.GL_LINE_LOOP, 2, 3);
            //// 3 - Arms
            //glDrawArrays();
            Gl.glDrawArrays(Gl.GL_LINE_LOOP, 5, 3);
            Gl.glDrawArrays(Gl.GL_LINE_LOOP, 8, 3);
            //// 4 - Fan
            //glDrawArrays();
            Gl.glDrawArrays(Gl.GL_LINE_LOOP, 11, 6);
            //// 5 - legs
            //glDrawArrays();	
            Gl.glDrawArrays(Gl.GL_LINE_LOOP, 17, 3);
            Gl.glDrawArrays(Gl.GL_LINE_LOOP, 20, 3);
            //// 6 - Nose 
            //glDrawArrays();
            Gl.glDrawArrays(Gl.GL_LINE_LOOP, 23, 4);
            //// 7 - Mouth
            //glDrawArrays();
            Gl.glDrawArrays(Gl.GL_LINE_LOOP, 27,4);


            Gl.glDisableVertexAttribArray(0);
        }
        public void Update()
        {

        }
        public void CleanUp()
        {
            sh.DestroyShader();
        }
    }
}
