using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxCharacter : MonoBehaviour
{
    SfxSystem sfxSystem;
    float delaySound = 0.3f;
    public float actualHorizontalSpeed;
    private Vector3 previousPosition;


    // Start is called before the first frame update
    void Start()
    {
        sfxSystem = (SfxSystem)GameObject.FindObjectOfType(typeof(SfxSystem));
    }

    // Update is called once per frame
    void Update()
    {
        actualHorizontalSpeed = ((new Vector3(transform.position.x, 0f, transform.position.z) - new Vector3(previousPosition.x, 0f, previousPosition.z)).magnitude) / Time.deltaTime;
        previousPosition = transform.position;
        if (actualHorizontalSpeed > 0.2f)
        {
            RaycastSurface();
            WalkingSound();
        }

    }
    private SfxSurfaceType sfxSurfaceType;

    public void RaycastSurface()
    {

        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position+ (Vector2.down*3f), Vector2.down, 1f);
    
        //if (Physics.Raycast(transform.position, -Vector3.up, out hit, 3.55f))
        if (hit.collider != null)
        {
            if (hit.transform.gameObject.layer <= 21) { sfxSurfaceType = SfxSurfaceType.CONCRETE; }
            if (hit.transform.gameObject.layer == 22) { sfxSurfaceType = SfxSurfaceType.GRAVEL; }
            if (hit.transform.gameObject.layer == 23) { sfxSurfaceType = SfxSurfaceType.WOOD; }
            if (hit.transform.gameObject.layer == 24) { sfxSurfaceType = SfxSurfaceType.METAL; }
            if (hit.transform.gameObject.layer == 25) { sfxSurfaceType = SfxSurfaceType.WATER; }
            if (hit.transform.gameObject.layer == 26) { sfxSurfaceType = SfxSurfaceType.SNOW; }
            if (hit.transform.gameObject.layer == 27) { sfxSurfaceType = SfxSurfaceType.SAND; }
            print(hit.transform.gameObject.layer);
        }
    }
    AudioClip sound;

    void PlayStepSound(float pitch, float volume)
    {
        if (sfxSurfaceType == SfxSurfaceType.CONCRETE)
        {
            sound = ResData.Sounds.Footsteps.concrete[Random.Range(0, ResData.Sounds.Footsteps.concrete.Length)];
        }
        if (sfxSurfaceType == SfxSurfaceType.METAL)
        {
            sound = ResData.Sounds.Footsteps.metal[Random.Range(0, ResData.Sounds.Footsteps.metal.Length)];
        }
        if (sfxSurfaceType == SfxSurfaceType.SNOW)
        {
            sound = ResData.Sounds.Footsteps.snow[Random.Range(0, ResData.Sounds.Footsteps.snow.Length)];
        }
        if (sfxSurfaceType == SfxSurfaceType.SAND)
        {
            // v ResData nie su audio clipy na sand
        }
        if (sfxSurfaceType == SfxSurfaceType.GRAVEL)
        {
            sound = ResData.Sounds.Footsteps.gravel[Random.Range(0, ResData.Sounds.Footsteps.gravel.Length)];
        }
        if (sfxSurfaceType == SfxSurfaceType.WOOD)
        {
            sound = ResData.Sounds.Footsteps.wood[Random.Range(0, ResData.Sounds.Footsteps.wood.Length)];
        }

        sfxSystem.PlaySound(transform.position, sound, 1f, 1f);
    }

    // sptavit timer ktory bude prehravat po nejakom case zvuk
    // ten casovac pokial bude vacsi ako 0 tk sa bude odcitavat pomocu time.deltatime

    private void WalkingSound()
    {

        if (delaySound <= 0f)
        {
            PlayStepSound(1f, 1f);
            //Debug.Log("Prehral som zvuk");
            delaySound = 0.3f;
        }
        else
        {
            delaySound -= Time.deltaTime;
        }

    }
}
