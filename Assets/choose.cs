using UnityEngine;
using UnityEngine.UI;

public class choose : MonoBehaviour
{
    [SerializeField] Sprite[] _bgs;
    [SerializeField] Sprite[] _hats;
    [SerializeField] Sprite[] _legsLeft;
    [SerializeField] Sprite[] _legsRight;
    [SerializeField] Sprite[] _pants;
    [SerializeField] Sprite[] _torsos;
    [SerializeField] Sprite[] _armsRight;
    [SerializeField] Sprite[] _armsLeft;
    [SerializeField] TMPro.TMP_Text _scoreText;
    [SerializeField] int score;
    [SerializeField] int[] priceSkin;
    [SerializeField] int[] priceBg;
    [SerializeField] TMPro.TMP_Text priceText;
    [SerializeField] int _skinid;
    [SerializeField] int _bgid;
    [SerializeField] Image bg;
    [SerializeField] Vector2[] hatLocalPos;
    [SerializeField] bool[] hatFlipX;
    [SerializeField] SpriteRenderer torso;
    [SerializeField] SpriteRenderer hat;
    [SerializeField] SpriteRenderer legLeft;
    [SerializeField] SpriteRenderer legRight;
    [SerializeField] SpriteRenderer pants;
    [SerializeField] SpriteRenderer armLeft;
    [SerializeField] SpriteRenderer armRight;
    [SerializeField] GameObject wolf;
    public bool isBg;

    private void Start()
    {
        _skinid = PlayerPrefs.GetInt("skinid", _skinid);
        score = PlayerPrefs.GetInt("score", 0);
        if (_scoreText!= null)
            _scoreText.text = "Î÷êè: " + score.ToString();
        if (priceText != null)
            priceText.text = priceSkin[_skinid].ToString();

        _bgid = PlayerPrefs.GetInt("bgid", _bgid);
        torso.sprite = _torsos[_skinid];
        hat.sprite = _hats[_skinid];
        hat.flipX = hatFlipX[_skinid];
        hat.transform.localPosition = hatLocalPos[_skinid];
        legLeft.sprite = _legsLeft[_skinid];
        legRight.sprite = _legsRight[_skinid];
        pants.sprite = _pants[_skinid];
        armLeft.sprite = _armsLeft[_skinid];
        armRight.sprite = _armsRight[_skinid];
        bg.sprite = _bgs[_bgid];
    }
    public void SkinidPlus()
    {
        if (!isBg)
        {
            if (_skinid < _torsos.Length - 1)
            {
                _skinid++;
                priceText.text = "Öåíà: " + priceSkin[_skinid].ToString();
                torso.sprite = _torsos[_skinid];
                hat.sprite = _hats[_skinid];
                hat.flipX = hatFlipX[_skinid];
                hat.transform.localPosition = hatLocalPos[_skinid];
                legLeft.sprite = _legsLeft[_skinid];
                legRight.sprite = _legsRight[_skinid];
                pants.sprite = _pants[_skinid];
                armLeft.sprite = _armsLeft[_skinid];
                armRight.sprite = _armsRight[_skinid];
                if (score >= priceSkin[_skinid])
                    PlayerPrefs.SetInt("skinid", _skinid);
            }
            else
            {
                _skinid = _torsos.Length - 1;
                PlayerPrefs.SetInt("skinid", _skinid);
            }
        }
        if (isBg)
        {
            if (_bgid < _bgs.Length - 1)
            {
                _bgid++;
                priceText.text = "Öåíà: " + priceBg[_bgid].ToString();
                bg.sprite = _bgs[_bgid];
                if (score >= priceBg[_bgid])
                    PlayerPrefs.SetInt("bgid", _bgid);
            }
            else
            {
                _bgid = _bgs.Length - 1;
                if (score >= priceBg[_bgid])
                    PlayerPrefs.SetInt("bgid", _bgid);
            }
        }
    }
    public void SkinidMinus()
    {
        if (!isBg)
        {
            if (_skinid > 0)
            {
                _skinid--;
                priceText.text = "Öåíà: " + priceSkin[_skinid].ToString();
                torso.sprite = _torsos[_skinid];
                hat.sprite = _hats[_skinid];
                hat.flipX = hatFlipX[_skinid];
                hat.transform.localPosition = hatLocalPos[_skinid];
                legLeft.sprite = _legsLeft[_skinid];
                legRight.sprite = _legsRight[_skinid];
                pants.sprite = _pants[_skinid];
                armLeft.sprite = _armsLeft[_skinid];
                armRight.sprite = _armsRight[_skinid];
                if (score >= priceSkin[_skinid])
                    PlayerPrefs.SetInt("skinid", _skinid);
            }
            else
            {
                _skinid = 0;
                if (score >= priceSkin[_skinid])
                    PlayerPrefs.SetInt("skinid", _bgid);
            }
        }

        if (isBg)
        {
            if (_bgid > 0)
            {
                _bgid--;
                priceText.text = "Öåíà: " + priceBg[_bgid].ToString();
                bg.sprite = _bgs[_bgid];
                PlayerPrefs.SetInt("bgid", _bgid);
            }
            else
            {
                _bgid = 0;
                PlayerPrefs.SetInt("bgid", _bgid);
            }
        }
    }
    public void Skin()
    {
        isBg = false;
    }
    public void Bg()
    {
        isBg = true;
    }
}
