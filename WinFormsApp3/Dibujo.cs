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
    }
}
