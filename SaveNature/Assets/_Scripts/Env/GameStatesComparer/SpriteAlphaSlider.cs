using UnityEngine ;
using System.Collections ;

public class SpriteAlphaSlider : MonoBehaviour
{
	[SerializeField]
	bool _increaseAlpha ;

    int _initialAlpha;

    void Awake()
    {
        _initialAlpha = _increaseAlpha ? 0 : 1;
    }

	public void _Animate ( float time )
	{
		if ( _increaseAlpha )
		{
			IncreaseAplha ( time ) ;
		}
		else
		{
			DecreaseAlpha ( time ) ;
		}
	}

	void IncreaseAplha ( float time )
	{
		iTween.ColorTo ( gameObject , iTween.Hash ( "a" , 1 , "time" , time ) ) ;
	}

	void DecreaseAlpha ( float time )
	{
		iTween.ColorTo ( gameObject , iTween.Hash ( "a" , 0 , "time" , time ) ) ;
	}

    void _Revert()
    {
        _increaseAlpha = false;
    }

    public void _GrowBack()
    {
        _increaseAlpha = false;
    }

    public void _GrowUp()
    {
        _increaseAlpha = true;
    }

    public void _Reset()
    {
        iTween.ColorTo(gameObject, iTween.Hash("a", _initialAlpha, "time", 1f));
    }
}
