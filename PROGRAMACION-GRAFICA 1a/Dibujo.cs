using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp3;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
namespace ProgranGraf
{
    internal class Dibujo
    {
        int ancho;
        int alto;
        public float moverhorizontal = 0f;
        public float moververtical = 0f;
       // public readonly float[] _vertices =
            public float[] _vertices =
        {
            //-0.5f, -0.5f, 0f, // Inferior derecho
            // -0.5f, 0.5f, 0f, // superior derecho
            // 0.5f,  0.5f, 0f,  // superior izquierdo
            // 0.5f, -0.5f, 0f, //inferior izquierdo
            0.1f,  0.5f, 0.0f, // top right
             0.1f, -0.5f, 0.0f, // bottom right
            -0.1f, -0.5f, 0.0f, // bottom left
            -0.1f,  0.5f, 0.0f, // top left

             0.5f,  0.1f, 0.0f, // top right
            -0.5f,  0.1f, 0.0f, // bottom right
            -0.5f, -0.1f, 0.0f, // bottom left
             0.5f,  -0.1f, 0.0f,
        };
        public readonly uint[] _indices =
        {
            // Note that indices start at 0!
            0, 1, 3, // The first triangle will be the top-right half of the triangle
            1, 2, 3, // Then the second will be the bottom-left half of the triangle
            0, 1, 3, // The first triangle will be the top-right half of the triangle
            1, 2, 3
        };
        // These are the handles to OpenGL objects. A handle is an integer representing where the object lives on the
        // graphics card. Consider them sort of like a pointer; we can't do anything with them directly, but we can
        // send them to OpenGL functions that need them.

        // What these objects are will be explained in OnLoad.
        public int _vertexBufferObject;

        public int _vertexArrayObject;
        public int _elementBufferObject;
        public float[] color = { 0f, 255f, 255f, 0f };
        // This class is a wrapper around a shader, which helps us manage it.
        // The shader class's code is in the Common project.
        // What shaders are and what they're used for will be explained later in this tutorial.
        // private Shader _shader;

        public void open()
        {
            ancho = 0;
            alto = 0;
        }
        public void Ventana(int ancho, int alto)
        {
            // And that's it! That's all it takes to create a window with OpenTK.
            var nativeWindowSettings = new NativeWindowSettings()
            {
                ClientSize = new Vector2i(ancho,alto),
                Title = "VENTANA DE DIBUJO",
                // This is needed to run on macos
                Flags = ContextFlags.ForwardCompatible,
            };

            // To create a new window, create a class that extends GameWindow, then call Run() on it.
            using (var window = new Window(GameWindowSettings.Default, nativeWindowSettings))
            {
                window.Run();
            }

            // And that's it! That's all it takes to create a window with OpenTK.
        }
        public void mover_pos_horizontal(float horizontal)
        {
            moverhorizontal = horizontal;
            _vertices[0] = _vertices[0] + horizontal;
            _vertices[3] = _vertices[3] + horizontal;
            _vertices[6] = _vertices[6] + horizontal;
            _vertices[9] = _vertices[9] + horizontal;

            _vertices[12] = _vertices[12] + horizontal;
            _vertices[15] = _vertices[15] + horizontal;
            _vertices[18] = _vertices[18] + horizontal;
            _vertices[21] = _vertices[21] + horizontal;
        }
        public void mover_pos_vertical(float vertical)
        {
            moververtical = vertical;
            _vertices[1] = _vertices[1] + vertical;
            _vertices[4] = _vertices[4] + vertical;
            _vertices[7] = _vertices[7] + vertical;
            _vertices[10] = _vertices[10] + vertical;

            _vertices[13] = _vertices[13] + vertical;
            _vertices[16] = _vertices[16] + vertical;
            _vertices[19] = _vertices[19] + vertical;
            _vertices[22] = _vertices[22] + vertical;
        }
        public (int, int) ObtenerTamañoVentana()
        {
            int ancho = Screen.PrimaryScreen.Bounds.Width; int alto = Screen.PrimaryScreen.Bounds.Height;
            return (ancho, alto);

        }
    }
}
