using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiton
{
    class Program
    {
        static void Main(string[] args)
        {
            Camera camera1 = Camera.GetCamera("Nikon");
            Camera camera2 = Camera.GetCamera("Canon");

            Console.WriteLine(camera1.Id);
            Console.WriteLine(camera2.Id);

            Console.ReadLine();
        }
    }
    class Camera
    {
        static Dictionary<string, Camera> _cameras = new Dictionary<string, Camera>();
         static object _lock = new object();
        public Guid Id { get; set; }


        private Camera()
        {
            Id = Guid.NewGuid();
        }
        public static Camera GetCamera(string brand)
        {
            lock (_lock)
            {
                if (!_cameras.ContainsKey(brand))
                {
                    _cameras.Add(brand,new Camera());
                }
            }
            return _cameras[brand];
        }
    }
}
