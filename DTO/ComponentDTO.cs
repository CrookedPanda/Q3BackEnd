using System;

namespace DTO
{
    public class ComponentDTO
    {
        public ComponentDTO(int code, int id1, int id2, int actions, int board, int port)
        {

        }
        public int code { get; set; }
        public int treeview_id { get; set; }
        public int treeview2_id { get; set; }
        public int actionsCount{ get; set; }
        public int board { get; set; }
        public int port { get; set; }
    }
}
