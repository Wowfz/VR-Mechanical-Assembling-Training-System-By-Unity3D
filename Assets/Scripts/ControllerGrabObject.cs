/*
 * Copyright (c) 2016 Razeware LLC
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using UnityEngine;

public enum Instruction_model_order
{
	dizuo,
    digan,
    zhou1,
    xiagan1,
    xiagan2,
    zhou2,
    shanggan,
	dengzhao,
	xuanniu
}

public enum chinesename
{
    底盘,
    底杆,
    轴1,
    下杆1,
    下杆2,
    轴2,
    上杆,
    灯罩,
    旋钮
}

public class ControllerGrabObject : MonoBehaviour
{
    private SteamVR_TrackedObject trackedObj;

    private GameObject collidingObject;
    private GameObject objectInHand;

    private GameObject NextAdjoinObject; //和手中对象相碰撞的下一个对象
    private GameObject PreviewAdjoinObject; //和手中对象相碰撞的上一个对象

    private GameObject object_disable;
    private FixedJoint joint1, joint2, joint3, joint4, joint5, joint6;

    private bool xiagan1=false, xiagan2=false;    //判定下杆1和下杆2有没有被拼装上去

    Instruction_model_order model = 0;

    Instruction_model_order next_model = Instruction_model_order.dengzhao;
    Instruction_model_order preview_model = 0;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }


    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
        //Debug.Log(collidingObject.name);
        //SetAdjoinObject (other);

    }

    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
        //SetAdjoinObject(other);
    }

    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }

        collidingObject = null;
    }

    private void SetCollidingObject(Collider col)
    {
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }

        collidingObject = col.gameObject;

    }

    /*	private void SetAdjoinObject(Collider col)
        {
            if (!collidingObject || !col.GetComponent<Rigidbody> ())
                return;

            AdjoinObject = col.gameObject;

            Debug.Log(AdjoinObject.name);

            //if(collidingObject.name == "底杆" && AdjoinObjec.name == "底座")
            //if (collidingObject.GetComponent<Transform> ().position.x)
            //	collidingObject.GetComponent<Transform> ().position.x = collidingObject.GetComponent<Transform> ().position.x;

        }
    */

    void Update()
    {
        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
           // GameObject Object1, Object2, Object3;
            //Object1 = GameObject.Find("底杆");
           // Object2 = GameObject.Find("轴1");
            //Object3 = GameObject.Find("下杆2");

           // Object1.transform.position = Object2.transform.position;
           // Object1.transform.rotation = Object2.transform.rotation;

            //Object3.transform.position = Object2.transform.position;
            //Object3.transform.rotation = Object2.transform.rotation;

            //var joint1 = AddFixedJoint();
            //joint1.connectedBody = Object2.GetComponent<Rigidbody>();

            // var joint2 = AddFixedJoint();
            // joint1.connectedBody = Object3.GetComponent<Rigidbody>();
        }

        if (Controller.GetHairTriggerDown())
        {

            if (collidingObject)
            {
                GrabObject();
            }
        }

        if (Controller.GetHairTrigger())
        {

            if (collidingObject)
            {



                if (objectInHand.name == "底座")
                    model = Instruction_model_order.dizuo;
                else if (objectInHand.name == "底杆")
                    model = Instruction_model_order.digan;
                else if (objectInHand.name == "轴1")
                    model = Instruction_model_order.zhou1;
                else if (objectInHand.name == "下杆1")
                    model = Instruction_model_order.xiagan1;
                else if (objectInHand.name == "下杆2")
                    model = Instruction_model_order.xiagan2;
                else if (objectInHand.name == "轴2")
                    model = Instruction_model_order.zhou2;
                else if (objectInHand.name == "上杆")
                    model = Instruction_model_order.shanggan;
                else if (objectInHand.name == "灯罩")
                    model = Instruction_model_order.dengzhao;
                else if (objectInHand.name == "旋钮")
                    model = Instruction_model_order.xuanniu;



                if (model > 0)
                    preview_model = model - 1;
                if (model < Instruction_model_order.dengzhao)
                    next_model = model + 1;

                if (next_model == Instruction_model_order.dizuo)
                    NextAdjoinObject = GameObject.Find("底座");
                else if (next_model == Instruction_model_order.digan)
                    NextAdjoinObject = GameObject.Find("底杆");
                else if (next_model == Instruction_model_order.zhou1)
                    NextAdjoinObject = GameObject.Find("轴1");
                else if (next_model == Instruction_model_order.xiagan1)
                    NextAdjoinObject = GameObject.Find("下杆1");
                else if (next_model == Instruction_model_order.xiagan2)
                    NextAdjoinObject = GameObject.Find("下杆2");
                else if (next_model == Instruction_model_order.zhou2)
                    NextAdjoinObject = GameObject.Find("轴2");
                else if (next_model == Instruction_model_order.shanggan)
                    NextAdjoinObject = GameObject.Find("上杆");
                else if (next_model == Instruction_model_order.dengzhao)
                    NextAdjoinObject = GameObject.Find("灯罩");
                else if (next_model == Instruction_model_order.xuanniu)
                    NextAdjoinObject = GameObject.Find("旋钮");

                Debug.Log(NextAdjoinObject.name);

                if (preview_model == Instruction_model_order.dizuo)
                    PreviewAdjoinObject = GameObject.Find("底座");
                else if (preview_model == Instruction_model_order.digan)
                    PreviewAdjoinObject = GameObject.Find("底杆");
                else if (preview_model == Instruction_model_order.zhou1)
                    PreviewAdjoinObject = GameObject.Find("轴1");
                else if (preview_model == Instruction_model_order.xiagan1)
                    PreviewAdjoinObject = GameObject.Find("下杆1");
                else if (preview_model == Instruction_model_order.xiagan2)
                    PreviewAdjoinObject = GameObject.Find("下杆2");
                else if (preview_model == Instruction_model_order.zhou2)
                    PreviewAdjoinObject = GameObject.Find("轴2");
                else if (preview_model == Instruction_model_order.shanggan)
                    PreviewAdjoinObject = GameObject.Find("上杆");
                else if (preview_model == Instruction_model_order.dengzhao)
                    PreviewAdjoinObject = GameObject.Find("灯罩");
                else if (preview_model == Instruction_model_order.xuanniu)
                    PreviewAdjoinObject = GameObject.Find("旋钮");

                Debug.Log(PreviewAdjoinObject.name);

                
                /*
                chinesename chname = 0;

                for (int i = 0; i < 9; i++)
                {
                    if (chname.ToString() != objectInHand.name || chname.ToString() != NextAdjoinObject.name || chname.ToString() != PreviewAdjoinObject.name)
                    {
                        object_disable = GameObject.Find(chname.ToString());
                        object_disable.transform.GetComponent<Collider>().enabled = false;
                    }

                    chname++;
                }
               */

                /*

                if (objectInHand.name=="下杆1" || objectInHand.name == "下杆2")
                {
                    if (Mathf.Abs(Mathf.Abs(PreviewAdjoinObject.GetComponent<Transform>().position.x - objectInHand.GetComponent<Transform>().position.x)) < 0.1f)
                        if (Mathf.Abs(Mathf.Abs(PreviewAdjoinObject.GetComponent<Transform>().position.y - objectInHand.GetComponent<Transform>().position.y) - 0.8f) < 0.1f)
                            if (Mathf.Abs(Mathf.Abs(PreviewAdjoinObject.GetComponent<Transform>().position.z - objectInHand.GetComponent<Transform>().position.z)) < 0.1f)
                            {
                                Debug.Log("next吸附上了！");    //next吸附判定
                                objectInHand.GetComponent<Transform>().position = PreviewAdjoinObject.GetComponent<Transform>().position;
                                objectInHand.GetComponent<Transform>().rotation = PreviewAdjoinObject.GetComponent<Transform>().rotation;

                                joint1 = objectInHand.AddComponent<FixedJoint>();
                                joint1.breakForce = 200000;
                                joint1.breakTorque = 200000;
                                joint1.connectedBody = PreviewAdjoinObject.GetComponent<Rigidbody>();
                            }
                }

                */




                {
                    if (Mathf.Abs(NextAdjoinObject.GetComponent<Transform>().position.x - objectInHand.GetComponent<Transform>().position.x) < 0.15f)
                        if (Mathf.Abs(NextAdjoinObject.GetComponent<Transform>().position.y - objectInHand.GetComponent<Transform>().position.y) < 0.15f)
                            if (Mathf.Abs(NextAdjoinObject.GetComponent<Transform>().position.z - objectInHand.GetComponent<Transform>().position.z) < 0.15f)
                            {
                                //Destroy(objectInHand.GetComponent<Rigidbody>());
                                //Destroy(NextAdjoinObject.GetComponent<Rigidbody>());
                                /*
                                if (objectInHand.name == "下杆1" || objectInHand.name == "下杆2")
                                {
                                    Destroy(objectInHand.GetComponent<Rigidbody>());
                                    objectInHand.transform.GetComponent<Collider>().enabled = false;
                                }
                                */
                                GameObject.Find("底座").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                                GameObject.Find("底座").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;



                                Debug.Log("next吸附上了！");    //next吸附判定
                                objectInHand.GetComponent<Transform>().position = NextAdjoinObject.GetComponent<Transform>().position;
                                objectInHand.GetComponent<Transform>().rotation = NextAdjoinObject.GetComponent<Transform>().rotation;

                                joint1 = objectInHand.AddComponent<FixedJoint>();
                                joint1.breakForce = 200000;
                                joint1.breakTorque = 200000;
                                joint1.connectedBody = NextAdjoinObject.GetComponent<Rigidbody>();

                                if (objectInHand.name == "下杆1")
                                {
                                    joint3 = objectInHand.AddComponent<FixedJoint>();
                                    joint3.breakForce = 200000;
                                    joint3.breakTorque = 200000;
                                    joint3.connectedBody = GameObject.Find("底杆").GetComponent<Rigidbody>();

                                    joint4 = objectInHand.AddComponent<FixedJoint>();
                                    joint4.breakForce = 200000;
                                    joint4.breakTorque = 200000;
                                    joint4.connectedBody = GameObject.Find("轴1").GetComponent<Rigidbody>();

                                }

                                if (objectInHand.name == "下杆2")
                                {
                                    joint5 = objectInHand.AddComponent<FixedJoint>();
                                    joint5.breakForce = 200000;
                                    joint5.breakTorque = 200000;
                                    joint5.connectedBody = GameObject.Find("底杆").GetComponent<Rigidbody>();

                                    joint6 = objectInHand.AddComponent<FixedJoint>();
                                    joint6.breakForce = 200000;
                                    joint6.breakTorque = 200000;
                                    joint6.connectedBody = GameObject.Find("轴1").GetComponent<Rigidbody>();

                                }

                                objectInHand.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;     //位置固定的关键！！！！！
                                objectInHand.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;     //位置固定的关键！！！！！

                            }

                    if (Mathf.Abs(PreviewAdjoinObject.GetComponent<Transform>().position.x - objectInHand.GetComponent<Transform>().position.x) < 0.15f)
                        if (Mathf.Abs(PreviewAdjoinObject.GetComponent<Transform>().position.y - objectInHand.GetComponent<Transform>().position.y) < 0.15f)
                            if (Mathf.Abs(PreviewAdjoinObject.GetComponent<Transform>().position.z - objectInHand.GetComponent<Transform>().position.z) < 0.15f)
                            {
                                //Destroy(objectInHand.GetComponent<Rigidbody>());
                                //Destroy(PreviewAdjoinObject.GetComponent<Rigidbody>());
                                /*
                                if (objectInHand.name == "下杆1" || objectInHand.name == "下杆2")
                                {
                                    Destroy(objectInHand.GetComponent<Rigidbody>());
                                    objectInHand.transform.GetComponent<Collider>().enabled = false;
                                }
                                */

                                GameObject.Find("底座").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                                GameObject.Find("底座").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

                                Debug.Log("preview吸附上了！");  //preview吸附判定
                                objectInHand.GetComponent<Transform>().position = PreviewAdjoinObject.GetComponent<Transform>().position;
                                objectInHand.GetComponent<Transform>().rotation = PreviewAdjoinObject.GetComponent<Transform>().rotation;

                                joint2 = objectInHand.AddComponent<FixedJoint>();
                                joint2.breakForce = 200000;
                                joint2.breakTorque = 200000;
                                joint2.connectedBody = PreviewAdjoinObject.GetComponent<Rigidbody>();

                                if (objectInHand.name == "下杆1")
                                {
                                    joint3 = objectInHand.AddComponent<FixedJoint>();
                                    joint3.breakForce = 200000;
                                    joint3.breakTorque = 200000;
                                    joint3.connectedBody = GameObject.Find("底杆").GetComponent<Rigidbody>();

                                    joint4 = objectInHand.AddComponent<FixedJoint>();
                                    joint4.breakForce = 200000;
                                    joint4.breakTorque = 200000;
                                    joint4.connectedBody = GameObject.Find("轴1").GetComponent<Rigidbody>();

                                }

                                if (objectInHand.name == "下杆2")
                                {
                                    joint5 = objectInHand.AddComponent<FixedJoint>();
                                    joint5.breakForce = 200000;
                                    joint5.breakTorque = 200000;
                                    joint5.connectedBody = GameObject.Find("底杆").GetComponent<Rigidbody>();

                                    joint6 = objectInHand.AddComponent<FixedJoint>();
                                    joint6.breakForce = 200000;
                                    joint6.breakTorque = 200000;
                                    joint6.connectedBody = GameObject.Find("轴1").GetComponent<Rigidbody>();

                                }


                                objectInHand.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                                objectInHand.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

                            }

                }

            }
        }

        if (Controller.GetHairTriggerUp())
        {
            if (objectInHand)
            {

                Debug.Log(objectInHand.GetComponent<Transform>().position);
                //检测手上物体位置
                ReleaseObject();

            }
        }

        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            Application.LoadLevel("Game");//重载场景
        }


    }

    private void GrabObject()
    {
        objectInHand = collidingObject;
        collidingObject = null;




        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();

       
        objectInHand.transform.GetComponent<Collider>().enabled = false;   //抓起时取消碰撞体\


        chinesename chname = 0;

        for (int i = 0; i < 9; i++)
        {
            if (chname.ToString() != objectInHand.name)
            {
                object_disable = GameObject.Find(chname.ToString());
                object_disable.transform.GetComponent<Collider>().enabled = false;
            }

            chname++;
        }
        
    }

    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 200000;
        fx.breakTorque = 200000;
        return fx;
    }

    private void ReleaseObject()
    {
        if (GetComponent<FixedJoint>())
        {
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
            objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
            objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
        }

        //if (objectInHand.name == "下杆1" || objectInHand.name == "下杆2")
        //objectInHand.transform.GetComponent<Collider>().enabled = false;    //避免穿模
        //Destroy(objectInHand.GetComponent<Rigidbody>());
           
        //else
            objectInHand.transform.GetComponent<Collider>().enabled = true;    //放下时回复碰撞体

        objectInHand = null;

        /*
        chinesename chname = 0;
        GameObject object_disable;
        for (int i = 0; i < 9; i++)
        {

                object_disable = GameObject.Find(chname.ToString());
                //object_disable.transform.GetComponent<Collider>().enabled = true;

            chname++;
        }
        */
    }
}
