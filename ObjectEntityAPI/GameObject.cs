using System;

namespace ObjectEntityAPI
{
    public class GameObject
    {
        public const byte MAX_COMPONENTS = 100;
        public const byte MAX_CHILDS = 100;
        
        private GameObject parent;
        private GameObject[] childeren;
        private int id = 0;
        private string name = "";

        private Component[] components;
        private LookupStrInt ids;
        private int compindex = 0;
        private int childindex = 0;
        private int coldex = 0;

        public GameObject(int id, string name)
        {
            components = new Component[MAX_COMPONENTS];
            childeren = new GameObject[MAX_CHILDS];
            for (int i = 0; i < MAX_COMPONENTS; i++)
            {
                components[i] = new Component(this);
                ids = new LookupStrInt(MAX_COMPONENTS);
            }
            this.id = id;
            this.name = name;
        }

        public void Update()
        {
            for (int i = 0; i < compindex; i++)
            {
                components[i].Update();
            }
        }

        ////////////////////////////////
        public bool HasComponent(string name)
        {
            return ids.HasEntry(name);
        }
        public bool HasComponent<T>()
        {
            for(int i = 0; i < compindex; i++)
                if (components[i] is T)
                    return true;
            return false;
        }
        ////////////////////////////////
        public T GetComponent<T>()
        {
            for (int i = 0; i < compindex; i++)
            {
                if (components[i] is T)
                    return (T)Convert.ChangeType(components[i], typeof(T));
            }
            return default(T);
        }
        public T GetComponent<T>(string name)
        {
            return (T)Convert.ChangeType(components[ids.GetEntry(name)], typeof(T));
        }
        public Component GetComponent(string name)
        {
            return components[ids.GetEntry(name)];
        }
        public Component GetComponent(short index)
        {
            return components[index];
        }
        ////////////////////////////////
        public void AddComponent(string name, Component com)
        {
            ids.AddEntry(name, compindex);
            components[compindex] = com;
            compindex++;
        }
        
        ////////////////////////////////
        public void SetColdex(int i)
        {
            coldex = i;
        }
        public void SetColAction(string i)
        {
            coldex = ids.GetEntry(i);
        }
        ////////////////////////////////
        private void setChild(GameObject g)
        {
            if(childindex < MAX_CHILDS)
            {
                childeren[childindex++] = g;
            }
        }
        public GameObject GetChild(int id)
        {
            for(int i = 0; i < childindex; i++)
            {
                if (childeren[i] != null)
                    if (childeren[i].id == id)
                        return childeren[i];
            }
            return null;
        }
        public GameObject GetChild(string name)
        {
            for (int i = 0; i < childindex; i++)
            {
                if (childeren[i] != null)
                    if (childeren[i].name == name)
                        return childeren[i];
            }
            return null;
        }
        public GameObject GetParent()
        {
            return parent;
        }
        public void SetChild(GameObject g)
        {
            setChild(g);
            g.parent = g;
        }
        public void SetParent(GameObject g)
        {
            parent = g;
            g.SetChild(g);
        }
        ////////////////////////////////
        public int GetComponentCount()
        {
            return compindex;
        }
        public int GetId()
        {
            return id;
        }
        public void SetId(int i)
        {
            id = i;
        }
        public string GetName()
        {
            return name;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public virtual void OnCollision(GameObject other)
        {
            components[coldex].GOReferenceFunction(other);
        }
    }
}