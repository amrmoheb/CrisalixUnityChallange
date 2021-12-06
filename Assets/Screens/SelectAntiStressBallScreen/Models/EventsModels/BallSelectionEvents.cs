using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSelectionEvents 
{
 //   Handle handle;
   public  class Handle
    {
       // TypeSelected typeSelected;
       public struct TypeSelected {
           public BallType type;
        }
        public struct ColorSelected
        {
            public int colorIndex;
        }
        public struct SizeSelected
        {
            public int sizeIndex;
        }
        public enum UpdateMenu {
             typeMenu,
             colorMenu,
             sizeMenu
        }
        public enum GetOverrideParamter {
        colorOverrideSize
        }
        


    }
    public class  Perform
    {
        public struct GetColorsForType
        {
       public  BallType type;
        }
        public struct GetSizesForTypeAndColor
        {
            public BallType type;
            public BallColor color;
        }
        public struct GetMapedColorForKey
        {
            public BallColor key;
        }
        public enum GetOverrideParamter
        {
            colorOverrideSize
        }
    }
    public class Present
    {
        public struct UpdateColorsMenu
        {
            public List<BallColor> colors;
        }
        public struct UpdateSizesMenu
        {
            public float max;
            public float min;
            public float step;
        }
        public struct UpdateStressBallColor 
        {
            public Color color;
        }
        public struct SetColorOverrideSize
        {
            public BallColor overrideSizeColor;
        }
    }
   public class Display
    {
        public struct UpdateTypeMenu
        {
            public List<string> elements;
        }
        public struct UpdateColorMenu
        {
            public List<string> colors;
        }
        public struct UpdateSizeMenu
        {
            public List<string> sizes;
        }
        public struct RenderStressBallColor
        {
            public Color color;
        }
        public struct RenderStressBallSize
        {
            public float scale;
        }
    }
}

