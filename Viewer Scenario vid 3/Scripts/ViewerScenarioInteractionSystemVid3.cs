using System.Collections;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.UI;

public class ViewerScenarioInteractionSystemVid3 : MonoBehaviour
{

    private bool CanInteract = true;

    public Text InteractionText;

    public InverntoryViewerScenarioVid3 InventoryScript;

    // dialouge

    public Text Subtext;
    private string holder;
    private float time = 0.025f;

    public GameObject Talkpanel;

    // dialouge

    // bool conditions

    private bool TalkedWithBatman = false;

    // bool 

    public GameObject FuelCanister_GO;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if(CanInteract == true)
        {


            Ray ray1 = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit1;

            if(Physics.Raycast(ray1, out hit1, 5))
            {

                if (hit1.collider.CompareTag("Batman"))
                {

                    InteractionText.text = "Talk to Batman";

                    

                    if (Input.GetMouseButtonDown(0))
                    {


                        if(TalkedWithBatman == false)
                        {


                            // talk with batman

                            StartCoroutine(TalkwithBatmanCO());


                        }
                        else if(TalkedWithBatman == true)
                        {


                            // batman talks

                            StartCoroutine(BatmanTalksCO());


                        }

                        


                    }



                }
                else if (hit1.collider.CompareTag("Canister"))
                {

                    InteractionText.text = "Take Fuel Canister";

                    if (Input.GetMouseButtonDown(0))
                    {


                        // take fuel canister

                        if(TalkedWithBatman == false)
                        {

                            // cant take

                            StartCoroutine(CantTakeFCCO());

                        }
                        else if(TalkedWithBatman == true)
                        {


                            // take

                            StartCoroutine(TakeFCCO());


                        }



                    }


                }
                else if (hit1.collider.CompareTag("Engine"))
                {


                    InteractionText.text = "Use";

                    if (Input.GetMouseButtonDown(0))
                    {


                        if(InventoryScript.HaveFuelCanister == true)
                        {


                            Debug.Log("Used Fuel Canister");


                        }
                        else
                        {


                            StartCoroutine(CantUseFCCO());


                        }


                    }



                }
                else
                {

                    InteractionText.text = "";



                }



            }
            else
            {


                InteractionText.text = "";


            }




        }



        
    }





    IEnumerator TalkwithBatmanCO()
    {

        CanInteract = false;

        InteractionText.text = "";

        Talkpanel.SetActive(true);

        Subtext.text = "Me: ";
        holder = "Hello batman, Do you have anything for me to do ?";
        foreach(char c in holder)
        {


            Subtext.text += c;
            yield return new WaitForSeconds(time);


        }

        yield return new WaitForSeconds(1f);

        Subtext.text = "Batman: ";
        holder = "Hello My friend, Yes I want you to take this fuel canister and use it later on";
        foreach (char c in holder)
        {


            Subtext.text += c;
            yield return new WaitForSeconds(time);


        }

        yield return new WaitForSeconds(1f);

        Subtext.text = "Me: ";
        holder = "Sure thing.";
        foreach (char c in holder)
        {


            Subtext.text += c;
            yield return new WaitForSeconds(time);


        }

        yield return new WaitForSeconds(1f);

        Subtext.text = "";
        Talkpanel.SetActive(false);
        CanInteract = true;

        // bool 

        TalkedWithBatman = true;

        // bool 




    }

    IEnumerator BatmanTalksCO()
    {

        CanInteract = false;

        InteractionText.text = "";

        Talkpanel.SetActive(true);

        Subtext.text = "Batman: ";
        holder = "Go ahead, we don't have much time";
        foreach(char c in holder)
        {


            Subtext.text += c;
            yield return new WaitForSeconds(time);


        }

        yield return new WaitForSeconds(1.5f);

        Talkpanel.SetActive(false);
        CanInteract = true;
        Subtext.text = "";




    }

    IEnumerator CantTakeFCCO()
    {

        CanInteract = false;

        InteractionText.text = "";

        Talkpanel.SetActive(true);

        Subtext.text = "";
        holder = "I don't need this at the moment";
        foreach(char c in holder)
        {


            Subtext.text += c;
            yield return new WaitForSeconds(time);


        }

        yield return new WaitForSeconds(1.5f);

        CanInteract = true;
        Subtext.text = "";
        Talkpanel.SetActive(false);




    }

    IEnumerator TakeFCCO()
    {


        

        InteractionText.text = "";

        FuelCanister_GO.SetActive(false);

        InventoryScript.HaveFuelCanister = true;

        CanInteract = true;

        yield return null;


    }

    IEnumerator CantUseFCCO()
    {


        CanInteract = false;

        InteractionText.text = "";

        Talkpanel.SetActive(true);

        Subtext.text = "";
        holder = "I need something to pour in it";
        foreach(char c in holder)
        {

            Subtext.text += c;
            yield return new WaitForSeconds(time);



        }

        yield return new WaitForSeconds(1.5f);

        CanInteract = true;
        Subtext.text = "";
        Talkpanel.SetActive(false);


    }


}
