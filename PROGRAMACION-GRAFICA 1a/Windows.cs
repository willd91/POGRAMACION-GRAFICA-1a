//using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;
using Keys = System.Windows.Forms.Keys;

namespace ProgranGraf
{
    public class Window : GameWindow
    {
       private Dibujo Dibujo1 = new Dibujo();
       

        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings)
        {
        }

        // Now, we start initializing OpenGL.
        protected override void OnLoad()
        {
            base.OnLoad();
            Dibujo1.mover_pos_horizontal(Dibujo1.moverhorizontal);
            Dibujo1.mover_pos_vertical(Dibujo1.moververtical);
         
         
            //GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            GL.ClearColor(Dibujo1.color[0], Dibujo1.color[1], Dibujo1.color[2], Dibujo1.color[3]);//Con esto se define el color de fondo.
        
           

           
            Dibujo1._vertexBufferObject = GL.GenBuffer();

          
            GL.BindBuffer(BufferTarget.ArrayBuffer, Dibujo1._vertexBufferObject);

          
            GL.BufferData(BufferTarget.ArrayBuffer, Dibujo1._vertices.Length * sizeof(float), Dibujo1._vertices, BufferUsageHint.StaticDraw);

         
            Dibujo1._vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(Dibujo1._vertexArrayObject);

          
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);

           
            GL.EnableVertexAttribArray(0);

           
            Dibujo1._elementBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, Dibujo1._elementBufferObject);
        
            GL.BufferData(BufferTarget.ElementArrayBuffer, Dibujo1._indices.Length * sizeof(uint), Dibujo1._indices, BufferUsageHint.StaticDraw);
           
        }

      
        protected override void OnRenderFrame(FrameEventArgs e)
        {
           
            base.OnRenderFrame(e);
            Dibujo1.mover_pos_horizontal(Dibujo1.moverhorizontal);
            Dibujo1.mover_pos_vertical(Dibujo1.moververtical);
          
            GL.Clear(ClearBufferMask.ColorBufferBit);

           
            GL.BindVertexArray(Dibujo1._vertexArrayObject);

          
            GL.DrawElements(PrimitiveType.Triangles, Dibujo1._indices.Length, DrawElementsType.UnsignedInt, 0);
          
            SwapBuffers();

           
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
           
            var input = KeyboardState;
           
            if (input.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.Escape))
            {
                 Close();
               
            };
            if (input.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.Left))
            {
                Dibujo1.moverhorizontal =- 0.5f;
            };
            if (input.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.Right))
            {
                Dibujo1.moverhorizontal =+ 0.5f;
            };
            if (input.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.Up))
            {
                Dibujo1.moververtical =+ 0.5f;
            };
            if (input.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.Down))
            {
                Dibujo1.moververtical =- 0.5f;
            }
            Dibujo1.mover_pos_horizontal(Dibujo1.moverhorizontal);
            Dibujo1.mover_pos_vertical(Dibujo1.moververtical);
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);

           
             GL.Viewport(0, 0, Size.X, Size.Y);
            
        }

      
        protected override void OnUnload()
        {

          
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
            GL.UseProgram(0);

           
           GL.DeleteBuffer(Dibujo1._vertexBufferObject);
            GL.DeleteVertexArray(Dibujo1._vertexArrayObject);

       

            base.OnUnload();
        }
        
    }
}
