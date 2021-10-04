using DAL;
using DTO;
using System;
using System.Collections.Generic;

namespace Logic
{
    public class ComponentLogic
    {
        private ComponentDAL _data;
        public ComponentLogic(ComponentDAL data)
        {
            _data = data;
        }

        public void Create(ComponentDTO component)
        {
            _data.Create(component);
        }

        public List<ComponentDTO> ReadAll()
        {
            return _data.ReadAll();
        }

        public void Delete(int code)
        {
            _data.Delete(code);
        }

        public void Update(ComponentDTO component)
        {
            _data.Update(component);
        }

        public ComponentDTO Read(int code)
        {
            return _data.Read(code);
        }
    }
}
