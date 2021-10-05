using System;

namespace DTO
{
    public class ComponentDTO
    {
        public int code { get; set; }
        public int actionsCount{ get; set; }
        public int board { get; set; }
        public int port { get; set; }


        public ComponentDTO(int c, int ac, int b, int p)
        {
            code = c;
            actionsCount = ac;
            board = b;
            port = p;
        }
    }
}
