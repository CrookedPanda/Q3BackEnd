using System;

namespace DTO
{
    public class ComponentDTO
    {
        public ComponentDTO(string naam, int id1, int actions, int board, int port)
        {
            this.naam = naam;
            treeview_id = id1;
            actionsCount = actions;
            this.board = board;
            this.port = port;
        }
        public string naam { get; set; }
        public int treeview_id { get; set; }
        public int actionsCount{ get; set; }
        public int board { get; set; }
        public int port { get; set; }
    }
}
