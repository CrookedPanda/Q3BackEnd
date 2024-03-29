﻿using DTO;
using System.Collections.Generic;

namespace Logic
{
    public interface Iproduction_dataLogic
    {
        IEnumerable<production_dataDTO> ReadAll();
        IEnumerable<production_dataDTO> GetByMachine(int port, int board);
        IEnumerable<ComponentDTO> GetAllComponents();
        ComponentDTO GetComponent(int treeview_id);
        LifepageDTO GetLifespan(int treeview_id);
        IEnumerable<LifepageDTO> GetAllLifespans();
        IEnumerable<ComponentDTO> GetComponentNames();
        string GetComponentNameString(int treeview_id);
    }
}