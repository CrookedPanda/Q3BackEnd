using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class ComponentDAL
    {
        //TEMPORARY REMOVE COMPONENT CONSTRUCTOR WHEN DATABASE FIXED
        List<ComponentDTO> components;
        public ComponentDAL()
        {
            components = new List<ComponentDTO>();
            components.Add(new ComponentDTO(111, 34005, 1, 12));
            components.Add(new ComponentDTO(112, 45005, 2, 13));
            components.Add(new ComponentDTO(113, 45000, 3, 14));
        }


        public void Create(ComponentDTO component) { 
        }

        public List<ComponentDTO> ReadAll() {
            return components;
        }

        public void Delete(int code) { 
        
        }

        public void Update(ComponentDTO component) { 
        
        }

        public ComponentDTO Read(int code) {
            return components.Single(c => c.code == code);
        }
    }
}
