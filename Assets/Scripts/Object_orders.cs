using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Instruction_order
{
    cube_rotation,
    cylinder_move,
    sphere_move
}


public class Object_orders:MonoBehaviour
{ 
    public static Instruction_order operation = 0;


    public static void Operationplus()
    {
        //if( operation>=Instruction_order.cube_rotation && operation < Instruction_order.sphere_move)
            operation++;
    }

    public static void Operationminus()
    {
        //if (operation > Instruction_order.cube_rotation && operation <= Instruction_order.sphere_move)
            operation--;
    }

    /*  static Object_order _instance;
        void Awake()
        {

            _instance = this;
        }

        public static Object_order Instance
        {
            get
            {
                // 不需要再检查变量是否为null
                return _instance;
            }
        }

    */
}



