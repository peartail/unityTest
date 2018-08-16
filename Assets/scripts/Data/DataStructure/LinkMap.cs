using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DS
{

    using Xpos = Int32;

    public class LinkLocation
    {
        HashSet<LinkLocation> nearLoc;
        internal int Locx;
        internal int Locy;
        internal LinkLocation(int x, int y)
        {
            nearLoc = new HashSet<LinkLocation>();
        }
    }

    public class LinkMap
    {

        HashSet<LinkLocation> locations;
        LinkLocation root;
        private LinkMap()
        {
            locations = new HashSet<LinkLocation>();
            root = null;
        }

        public void AddLocation(int x, int y)
        {
            
            LinkLocation loc = new LinkLocation(x, y);
            locations.Add(loc);


        }

        public void AddNearLocation(LinkLocation loc)
        {

        }

        private bool CheckNearlist(int x, int y)
        {
            var iter = locations.GetEnumerator();
            while (iter.MoveNext())
            {
                LinkLocation compare = iter.Current;
                
                    
                if (iter.Current.Locx == x && iter.Current.Locy == y)
                {
                    return false;
                }
            }
            return true;
        }

        public static LinkMap Create()
        {
            LinkMap map = new LinkMap();
            return map;
        }
    }

}

