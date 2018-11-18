using Lockethot.Collections.Extensions;
using System.Collections.Generic;

namespace Lockethot.Design.Structural.EntityComponentPattern
{
    public class Entity : Part
    {
        protected readonly List<object> _Components = new List<object>();
        protected readonly List<object> _Children = new List<object>();

        public Component[] Components
        {
            get
            {
                var ret = new List<Component>();
                for(var i = 0; i < _Components.Count; i ++)
                {
                    ret.Add((Component)_Components[i]);
                }
                return ret.ToArray();
            }
        }

        public Entity[] Children
        {
            get
            {
                var ret = new List<Entity>();
                for (var i = 0; i < _Children.Count; i++)
                {
                    ret.Add((Entity)_Children[i]);
                }
                return ret.ToArray();
            }
        }

        public void AddComponent(Component component)
        {
            if (_Components.Contains(component))
            {
                throw new ComponentDuplicateException();
            }
            _Components.Add(component);
            component.Parent = this;
        }

        public T GetComponent<T>()
        {
            for (var i = 0; i < _Components.Count; i++)
            {
                if (_Components[i] is T)
                {
                    return (T)_Components[i];
                }
            }
            throw new ComponentNotFoundException(typeof(T));
        }

        public T[] GetComponents<T>()
        {
            var ret = new List<T>();
            for (var i = 0; i < _Components.Count; i ++)
            {
                if (_Components[i] is T)
                {
                    ret.Add((T)_Components[i]);
                }
            }
            return ret.ToArray();
        }

        public T RemoveComponent<T>()
        {
            for (var i = 0; i < _Components.Count; i++)
            {
                if (_Components[i] is T)
                {
                    ((Component)_Components[i]).Parent = null;
                    return (T)_Components.PopAt(i);
                }
            }
            throw new ComponentNotFoundException(typeof(T));
        }

        public T[] RemoveComponents<T>()
        {
            var ret = new List<T>();
            for (var i = 0; i < _Components.Count; i++)
            {
                if (_Components[i] is T)
                {
                    ((Component)_Components[i]).Parent = null;
                    ret.Add((T)_Components.PopAt(i));
                }
            }
            return ret.ToArray();
        }

        public void RemoveComponent(Component component)
        {
            for(var i = 0; i < _Components.Count; i ++)
            {
                if (_Components[i] == component)
                {
                    component.Parent = null;
                    _Components.RemoveAt(i);
                    return;
                }
            }
            throw new ComponentNotFoundException(component.GetType());
        }

        public void AddChild(Entity entity)
        {
            if (_Children.Contains(entity))
            {
                throw new DuplicateChildException();
            }
            entity.Parent = this;
            _Children.Add(entity);
        }

        public void RemoveChild(Entity entity)
        {
            for (var i = 0; i < _Children.Count; i++)
            {
                if (_Children[i] == entity)
                {
                    entity.Parent = null;
                    _Children.RemoveAt(i);
                    return;
                }
            }
            throw new ComponentNotFoundException(entity.GetType());
        }
    }
}
