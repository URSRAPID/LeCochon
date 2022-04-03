using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private List<DesView> _tileViews;
    private LeCochonModel _gridModel;


    [SerializeField] GameObject _tileViewPrefab;

    [SerializeField] Button _player1;
    [SerializeField] Button _player2;

    private bool Joueur;
    public int ScorePlayer1 = 0;
    public int ScorePlayer2 = 0;
    // Start is called before the first frame update
    void Start()
    {

        //Instanciation de _tileViews
        _tileViews = new List<DesView>();

        //Création du Model
        _gridModel = new LeCochonModel();

        //Création de la Vue
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 1; y++)
            {
                //Création d'une tuile (TileView)
                GameObject tileGO = Instantiate(_tileViewPrefab, new Vector3(x, y, 0), Quaternion.identity);
                DesView tileView = tileGO.GetComponent<DesView>();
                //"Constructeur d'un MonoBehaviour"
                tileView.Init(x, y);

                //Ajout dans la liste des tileViews
                _tileViews.Add(tileGO.GetComponent<DesView>());
            }
        }

        _player1.onClick.AddListener(Player1);
        _player2.onClick.AddListener(Player2);

       
        //couplage faible Vue -> Controller
        //Pour récupérer les évenements de clic sur les tuiles
        foreach (DesView tile in _tileViews)
        {
            
            //Couplage faible Model -> Vue
            _gridModel.Subscribe(tile.GetX(), tile.GetY(), tile);
        }

        Joueur = true;
      
       
    }

    private void Player2()
    {
        RandomValue();
        Player2Brelan();
        Player2Paire();
        Player2Suite();
        Player2Cochon();
        if (ScorePlayer2 >=30)
        {
            SceneManager.LoadScene("FelicitationsJouer2");
        }
    }

    private void Player1()
    {
        RandomValue();
        Player1Brelan();
        Player1Paire();
        Player1Suite();
        Player1Cochon();
        if(ScorePlayer1 >=30)
        {
            SceneManager.LoadScene("FelicitationsJoueur1");
        }
    }

    public void RandomValue()
    {
        int Nombre;
       
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 1; y++)
            {
                for (int j = 0; j < 1; j++)
                {
                    Nombre = Random.Range(1, 6);
                    if (Nombre == 1)
                    {
                        _gridModel.Set(x, y, VALUE.Un);
                    }
                    else if (Nombre == 2)
                    {
                        _gridModel.Set(x, y, VALUE.Deux);
                    }
                    else if (Nombre == 3)
                    {
                        _gridModel.Set(x, y, VALUE.Trois);
                    }
                    else if (Nombre == 4)
                    {
                        _gridModel.Set(x, y, VALUE.Quatre);
                    }
                    else if (Nombre == 5)
                    {
                        _gridModel.Set(x, y, VALUE.Cinq);
                    }
                    else
                    {
                        _gridModel.Set(x, y, VALUE.Six);
                    }
                   
                }
            }
        }
       
       
    }

    
    public void Player1Brelan()
    {
      
        
        if (_gridModel.GetValue(1,0)== VALUE.Un && _gridModel.GetValue(2, 0) == VALUE.Un && _gridModel.GetValue(0, 0) == VALUE.Un)
        {
            Debug.Log("Player 1 a castigat 2 ");
            ScorePlayer1 = ScorePlayer1 + 2;
        }
        else if (_gridModel.GetValue(1, 0) == VALUE.Deux && _gridModel.GetValue(2, 0) == VALUE.Deux && _gridModel.GetValue(0, 0) == VALUE.Deux)
        {
            Debug.Log("Player 1 a castigat 4 ");
            ScorePlayer1 = ScorePlayer1 + 4;
        }
        else if (_gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Trois && _gridModel.GetValue(0, 0) == VALUE.Trois)
        {
            Debug.Log("Player 1 a castigat 6 ");
            ScorePlayer1 = ScorePlayer1 + 6;
        }
        else if (_gridModel.GetValue(1, 0) == VALUE.Quatre && _gridModel.GetValue(2, 0) == VALUE.Quatre && _gridModel.GetValue(0, 0) == VALUE.Quatre)
        {
            Debug.Log("Player 1 a castigat 8 ");
            ScorePlayer1 = ScorePlayer1 + 8;
        }
        else if (_gridModel.GetValue(1, 0) == VALUE.Cinq && _gridModel.GetValue(2, 0) == VALUE.Cinq && _gridModel.GetValue(0, 0) == VALUE.Cinq)
        {
            Debug.Log("Player 1 a castigat 10 ");
            ScorePlayer1 = ScorePlayer1 + 10;
        }
        else if (_gridModel.GetValue(1, 0) == VALUE.Six && _gridModel.GetValue(2, 0) == VALUE.Six && _gridModel.GetValue(0, 0) == VALUE.Six)
        {
            Debug.Log("Player 1 a castigat 12 ");
            ScorePlayer1 = ScorePlayer1 + 12;
        }

    }
    public void Player2Brelan()
    {


        if (_gridModel.GetValue(1, 0) == VALUE.Un && _gridModel.GetValue(2, 0) == VALUE.Un && _gridModel.GetValue(0, 0) == VALUE.Un)
        {
            Debug.Log("Player 2 a castigat 2 ");
            ScorePlayer2 = ScorePlayer2 + 2;
        }
        else if (_gridModel.GetValue(1, 0) == VALUE.Deux && _gridModel.GetValue(2, 0) == VALUE.Deux && _gridModel.GetValue(0, 0) == VALUE.Deux)
        {
            Debug.Log("Player 2 a castigat 4 ");
            ScorePlayer2 = ScorePlayer2 + 4;
        }
        else if (_gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Trois && _gridModel.GetValue(0, 0) == VALUE.Trois)
        {
            Debug.Log("Player 2 a castigat 6 ");
            ScorePlayer2 = ScorePlayer2 + 6;
        }
        else if (_gridModel.GetValue(1, 0) == VALUE.Quatre && _gridModel.GetValue(2, 0) == VALUE.Quatre && _gridModel.GetValue(0, 0) == VALUE.Quatre)
        {
            Debug.Log("Player 2 a castigat 8 ");
            ScorePlayer2 = ScorePlayer2 + 8;
        }
        else if (_gridModel.GetValue(1, 0) == VALUE.Cinq && _gridModel.GetValue(2, 0) == VALUE.Cinq && _gridModel.GetValue(0, 0) == VALUE.Cinq)
        {
            Debug.Log("Player 2 a castigat 10 ");
            ScorePlayer2 = ScorePlayer2 + 10;
        }
        else if (_gridModel.GetValue(1, 0) == VALUE.Six && _gridModel.GetValue(2, 0) == VALUE.Six && _gridModel.GetValue(0, 0) == VALUE.Six)
        {
            Debug.Log("Player 2 a castigat 12 ");
            ScorePlayer2 = ScorePlayer2 + 12;
        }

    }

    public void Player1Paire()
    {
        if (_gridModel.GetValue(0, 0) == VALUE.Un && _gridModel.GetValue(1, 0) == VALUE.Un && _gridModel.GetValue(2, 0) == VALUE.Deux || _gridModel.GetValue(0, 0) == VALUE.Un && _gridModel.GetValue(1, 0) == VALUE.Deux && _gridModel.GetValue(2, 0) == VALUE.Un || _gridModel.GetValue(0, 0) == VALUE.Deux && _gridModel.GetValue(1, 0) == VALUE.Un && _gridModel.GetValue(2, 0) == VALUE.Un)
        {
            Debug.Log("Player 1 a castigat 1 ");
            ScorePlayer1 = ScorePlayer1 + 1;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Un && _gridModel.GetValue(1, 0) == VALUE.Un && _gridModel.GetValue(2, 0) == VALUE.Trois || _gridModel.GetValue(0, 0) == VALUE.Un && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Un || _gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Un && _gridModel.GetValue(2, 0) == VALUE.Un)
        {
            Debug.Log("Player 1 a castigat 1 ");
            ScorePlayer1 = ScorePlayer1 + 1;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Un && _gridModel.GetValue(1, 0) == VALUE.Un && _gridModel.GetValue(2, 0) == VALUE.Quatre || _gridModel.GetValue(0, 0) == VALUE.Un && _gridModel.GetValue(1, 0) == VALUE.Quatre && _gridModel.GetValue(2, 0) == VALUE.Un || _gridModel.GetValue(0, 0) == VALUE.Quatre && _gridModel.GetValue(1, 0) == VALUE.Un && _gridModel.GetValue(2, 0) == VALUE.Un)
        {
            Debug.Log("Player 1 a castigat 1 ");
            ScorePlayer1 = ScorePlayer1 + 1;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Un && _gridModel.GetValue(1, 0) == VALUE.Un && _gridModel.GetValue(2, 0) == VALUE.Cinq || _gridModel.GetValue(0, 0) == VALUE.Un && _gridModel.GetValue(1, 0) == VALUE.Cinq && _gridModel.GetValue(2, 0) == VALUE.Un || _gridModel.GetValue(0, 0) == VALUE.Cinq && _gridModel.GetValue(1, 0) == VALUE.Un && _gridModel.GetValue(2, 0) == VALUE.Un)
        {
            Debug.Log("Player 1 a castigat 1 ");
            ScorePlayer1 = ScorePlayer1 + 1;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Un && _gridModel.GetValue(1, 0) == VALUE.Un && _gridModel.GetValue(2, 0) == VALUE.Six || _gridModel.GetValue(0, 0) == VALUE.Un && _gridModel.GetValue(1, 0) == VALUE.Six && _gridModel.GetValue(2, 0) == VALUE.Un || _gridModel.GetValue(0, 0) == VALUE.Six && _gridModel.GetValue(1, 0) == VALUE.Un && _gridModel.GetValue(2, 0) == VALUE.Un)
        {
            Debug.Log("Player 1 a castigat 1 ");
            ScorePlayer1 = ScorePlayer1 + 1;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Deux && _gridModel.GetValue(1, 0) == VALUE.Deux && _gridModel.GetValue(2, 0) == VALUE.Un || _gridModel.GetValue(0, 0) == VALUE.Deux && _gridModel.GetValue(1, 0) == VALUE.Un && _gridModel.GetValue(2, 0) == VALUE.Deux || _gridModel.GetValue(0, 0) == VALUE.Un &&  _gridModel.GetValue(1, 0) == VALUE.Deux && _gridModel.GetValue(2, 0) == VALUE.Deux)
        {
            Debug.Log("Player 1 a castigat 2 ");
            ScorePlayer1 = ScorePlayer1 + 2;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Deux && _gridModel.GetValue(1, 0) == VALUE.Deux && _gridModel.GetValue(2, 0) == VALUE.Trois || _gridModel.GetValue(0, 0) == VALUE.Deux && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Deux || _gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Deux && _gridModel.GetValue(2, 0) == VALUE.Deux)
        {
            Debug.Log("Player 1 a castigat 2 ");
            ScorePlayer1 = ScorePlayer1 + 2;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Deux && _gridModel.GetValue(1, 0) == VALUE.Deux && _gridModel.GetValue(2, 0) == VALUE.Quatre || _gridModel.GetValue(0, 0) == VALUE.Deux && _gridModel.GetValue(1, 0) == VALUE.Quatre && _gridModel.GetValue(2, 0) == VALUE.Deux || _gridModel.GetValue(0, 0) == VALUE.Quatre && _gridModel.GetValue(1, 0) == VALUE.Deux && _gridModel.GetValue(2, 0) == VALUE.Deux)
        {
            Debug.Log("Player 1 a castigat 2 ");
            ScorePlayer1 = ScorePlayer1 + 2;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Deux && _gridModel.GetValue(1, 0) == VALUE.Deux && _gridModel.GetValue(2, 0) == VALUE.Cinq || _gridModel.GetValue(0, 0) == VALUE.Deux && _gridModel.GetValue(1, 0) == VALUE.Cinq && _gridModel.GetValue(2, 0) == VALUE.Deux || _gridModel.GetValue(0, 0) == VALUE.Cinq && _gridModel.GetValue(1, 0) == VALUE.Deux && _gridModel.GetValue(2, 0) == VALUE.Deux)
        {
            Debug.Log("Player 1 a castigat 2 ");
            ScorePlayer1 = ScorePlayer1 + 2;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Deux && _gridModel.GetValue(1, 0) == VALUE.Deux && _gridModel.GetValue(2, 0) == VALUE.Six || _gridModel.GetValue(0, 0) == VALUE.Deux && _gridModel.GetValue(1, 0) == VALUE.Six && _gridModel.GetValue(2, 0) == VALUE.Deux || _gridModel.GetValue(0, 0) == VALUE.Six && _gridModel.GetValue(1, 0) == VALUE.Deux && _gridModel.GetValue(2, 0) == VALUE.Deux)
        {
            Debug.Log("Player 1 a castigat 2 ");
            ScorePlayer1 = ScorePlayer1 + 2;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Un || _gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Un &&  _gridModel.GetValue(2, 0) == VALUE.Trois || _gridModel.GetValue(0, 0) == VALUE.Un && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Trois)
        {
            Debug.Log("Player 1 a castigat 3 ");
            ScorePlayer1 = ScorePlayer1 + 3;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Deux || _gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Deux && _gridModel.GetValue(2, 0) == VALUE.Trois || _gridModel.GetValue(0, 0) == VALUE.Deux && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Trois)
        {
            Debug.Log("Player 1 a castigat 3 ");
            ScorePlayer1 = ScorePlayer1 + 3;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Quatre || _gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Quatre && _gridModel.GetValue(2, 0) == VALUE.Trois || _gridModel.GetValue(0, 0) == VALUE.Quatre && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Trois)
        {
            Debug.Log("Player 1 a castigat 3 ");
            ScorePlayer1 = ScorePlayer1 + 3;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Cinq || _gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Cinq && _gridModel.GetValue(2, 0) == VALUE.Trois || _gridModel.GetValue(0, 0) == VALUE.Cinq && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Trois)
        {
            Debug.Log("Player 1 a castigat 3 ");
            ScorePlayer1 = ScorePlayer1 + 3;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Six || _gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Six && _gridModel.GetValue(2, 0) == VALUE.Trois || _gridModel.GetValue(0, 0) == VALUE.Six && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Trois)
        {
            Debug.Log("Player 1 a castigat 3 ");
            ScorePlayer1 = ScorePlayer1 + 3;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Quatre && _gridModel.GetValue(1, 0) == VALUE.Quatre && _gridModel.GetValue(2, 0) == VALUE.Un || _gridModel.GetValue(0, 0) == VALUE.Quatre && _gridModel.GetValue(1, 0) == VALUE.Un && _gridModel.GetValue(2, 0) == VALUE.Quatre || _gridModel.GetValue(0, 0) == VALUE.Un && _gridModel.GetValue(1, 0) == VALUE.Quatre && _gridModel.GetValue(2, 0) == VALUE.Quatre)
        {
            Debug.Log("Player 1 a castigat 4 ");
            ScorePlayer1 = ScorePlayer1 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Quatre && _gridModel.GetValue(1, 0) == VALUE.Quatre && _gridModel.GetValue(2, 0) == VALUE.Deux || _gridModel.GetValue(0, 0) == VALUE.Quatre && _gridModel.GetValue(1, 0) == VALUE.Deux && _gridModel.GetValue(2, 0) == VALUE.Quatre || _gridModel.GetValue(0, 0) == VALUE.Deux && _gridModel.GetValue(1, 0) == VALUE.Quatre && _gridModel.GetValue(2, 0) == VALUE.Quatre)
        {
            Debug.Log("Player 1 a castigat 4 ");
            ScorePlayer1 = ScorePlayer1 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Quatre && _gridModel.GetValue(1, 0) == VALUE.Quatre && _gridModel.GetValue(2, 0) == VALUE.Trois || _gridModel.GetValue(0, 0) == VALUE.Quatre && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Quatre || _gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Quatre && _gridModel.GetValue(2, 0) == VALUE.Quatre)
        {
            Debug.Log("Player 1 a castigat 4 ");
            ScorePlayer1 = ScorePlayer1 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Quatre && _gridModel.GetValue(1, 0) == VALUE.Quatre && _gridModel.GetValue(2, 0) == VALUE.Cinq || _gridModel.GetValue(0, 0) == VALUE.Quatre && _gridModel.GetValue(1, 0) == VALUE.Cinq && _gridModel.GetValue(2, 0) == VALUE.Quatre || _gridModel.GetValue(0, 0) == VALUE.Cinq && _gridModel.GetValue(1, 0) == VALUE.Quatre && _gridModel.GetValue(2, 0) == VALUE.Quatre)
        {
            Debug.Log("Player 1 a castigat 4 ");
            ScorePlayer1 = ScorePlayer1 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Quatre && _gridModel.GetValue(1, 0) == VALUE.Quatre && _gridModel.GetValue(2, 0) == VALUE.Six || _gridModel.GetValue(0, 0) == VALUE.Quatre && _gridModel.GetValue(1, 0) == VALUE.Six && _gridModel.GetValue(2, 0) == VALUE.Quatre || _gridModel.GetValue(0, 0) == VALUE.Six && _gridModel.GetValue(1, 0) == VALUE.Quatre && _gridModel.GetValue(2, 0) == VALUE.Quatre)
        {
            Debug.Log("Player 1 a castigat 4 ");
            ScorePlayer1 = ScorePlayer1 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Cinq && _gridModel.GetValue(1, 0) == VALUE.Cinq && _gridModel.GetValue(2, 0) == VALUE.Un || _gridModel.GetValue(0, 0) == VALUE.Cinq && _gridModel.GetValue(1, 0) == VALUE.Un && _gridModel.GetValue(2, 0) == VALUE.Cinq || _gridModel.GetValue(0, 0) == VALUE.Un && _gridModel.GetValue(1, 0) == VALUE.Cinq && _gridModel.GetValue(2, 0) == VALUE.Cinq)
        {
            Debug.Log("Player 1 a castigat 5 ");
            ScorePlayer1 = ScorePlayer1 + 5;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Cinq && _gridModel.GetValue(1, 0) == VALUE.Cinq && _gridModel.GetValue(2, 0) == VALUE.Deux || _gridModel.GetValue(0, 0) == VALUE.Cinq && _gridModel.GetValue(1, 0) == VALUE.Deux && _gridModel.GetValue(2, 0) == VALUE.Cinq || _gridModel.GetValue(0, 0) == VALUE.Deux && _gridModel.GetValue(1, 0) == VALUE.Cinq && _gridModel.GetValue(2, 0) == VALUE.Cinq)
        {
            Debug.Log("Player 1 a castigat 5 ");
            ScorePlayer1 = ScorePlayer1 + 5;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Cinq && _gridModel.GetValue(1, 0) == VALUE.Cinq && _gridModel.GetValue(2, 0) == VALUE.Trois || _gridModel.GetValue(0, 0) == VALUE.Cinq && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Cinq || _gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Cinq && _gridModel.GetValue(2, 0) == VALUE.Cinq)
        {
            Debug.Log("Player 1 a castigat 5 ");
            ScorePlayer1 = ScorePlayer1 + 5;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Cinq && _gridModel.GetValue(1, 0) == VALUE.Cinq && _gridModel.GetValue(2, 0) == VALUE.Quatre || _gridModel.GetValue(0, 0) == VALUE.Cinq && _gridModel.GetValue(1, 0) == VALUE.Quatre && _gridModel.GetValue(2, 0) == VALUE.Cinq || _gridModel.GetValue(0, 0) == VALUE.Quatre && _gridModel.GetValue(1, 0) == VALUE.Cinq && _gridModel.GetValue(2, 0) == VALUE.Cinq)
        {
            Debug.Log("Player 1 a castigat 5 ");
            ScorePlayer1 = ScorePlayer1 + 5;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Cinq && _gridModel.GetValue(1, 0) == VALUE.Cinq && _gridModel.GetValue(2, 0) == VALUE.Six || _gridModel.GetValue(0, 0) == VALUE.Cinq && _gridModel.GetValue(1, 0) == VALUE.Six && _gridModel.GetValue(2, 0) == VALUE.Cinq || _gridModel.GetValue(0, 0) == VALUE.Six && _gridModel.GetValue(1, 0) == VALUE.Cinq && _gridModel.GetValue(2, 0) == VALUE.Cinq)
        {
            Debug.Log("Player 1 a castigat 5 ");
            ScorePlayer1 = ScorePlayer1 + 5;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Six && _gridModel.GetValue(1, 0) == VALUE.Six && _gridModel.GetValue(2, 0) == VALUE.Un || _gridModel.GetValue(0, 0) == VALUE.Six && _gridModel.GetValue(1, 0) == VALUE.Un && _gridModel.GetValue(2, 0) == VALUE.Six || _gridModel.GetValue(0, 0) == VALUE.Un && _gridModel.GetValue(1, 0) == VALUE.Six && _gridModel.GetValue(2, 0) == VALUE.Six)
        {
            Debug.Log("Player 1 a castigat 6 ");
            ScorePlayer1 = ScorePlayer1 + 6;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Six && _gridModel.GetValue(1, 0) == VALUE.Six && _gridModel.GetValue(2, 0) == VALUE.Deux || _gridModel.GetValue(0, 0) == VALUE.Six && _gridModel.GetValue(1, 0) == VALUE.Deux && _gridModel.GetValue(2, 0) == VALUE.Six || _gridModel.GetValue(0, 0) == VALUE.Deux && _gridModel.GetValue(1, 0) == VALUE.Six && _gridModel.GetValue(2, 0) == VALUE.Six)
        {
            Debug.Log("Player 1 a castigat 6 ");
            ScorePlayer1 = ScorePlayer1 + 6;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Six && _gridModel.GetValue(1, 0) == VALUE.Six && _gridModel.GetValue(2, 0) == VALUE.Trois || _gridModel.GetValue(0, 0) == VALUE.Six && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Six || _gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Six && _gridModel.GetValue(2, 0) == VALUE.Six)
        {
            Debug.Log("Player 1 a castigat 6 ");
            ScorePlayer1 = ScorePlayer1 + 6;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Six && _gridModel.GetValue(1, 0) == VALUE.Six && _gridModel.GetValue(2, 0) == VALUE.Quatre || _gridModel.GetValue(0, 0) == VALUE.Six && _gridModel.GetValue(1, 0) == VALUE.Quatre && _gridModel.GetValue(2, 0) == VALUE.Six || _gridModel.GetValue(0, 0) == VALUE.Quatre && _gridModel.GetValue(1, 0) == VALUE.Six && _gridModel.GetValue(2, 0) == VALUE.Six)
        {
            Debug.Log("Player 1 a castigat 6 ");
            ScorePlayer1 = ScorePlayer1 + 6;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Six && _gridModel.GetValue(1, 0) == VALUE.Six && _gridModel.GetValue(2, 0) == VALUE.Cinq || _gridModel.GetValue(0, 0) == VALUE.Six && _gridModel.GetValue(1, 0) == VALUE.Cinq && _gridModel.GetValue(2, 0) == VALUE.Six || _gridModel.GetValue(0, 0) == VALUE.Cinq && _gridModel.GetValue(1, 0) == VALUE.Six && _gridModel.GetValue(2, 0) == VALUE.Six)
        {
            Debug.Log("Player 1 a castigat 6 ");
            ScorePlayer1 = ScorePlayer1 + 6;
        }
      
    }

    public void Player2Paire()
    {
        if (_gridModel.GetValue(0, 0) == VALUE.Un && _gridModel.GetValue(1, 0) == VALUE.Un && _gridModel.GetValue(2, 0) == VALUE.Deux || _gridModel.GetValue(0, 0) == VALUE.Un && _gridModel.GetValue(1, 0) == VALUE.Deux && _gridModel.GetValue(2, 0) == VALUE.Un || _gridModel.GetValue(0, 0) == VALUE.Deux && _gridModel.GetValue(1, 0) == VALUE.Un && _gridModel.GetValue(2, 0) == VALUE.Un)
        {
            Debug.Log("Player 2 a castigat 1 ");
            ScorePlayer2 = ScorePlayer2 + 1;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Un && _gridModel.GetValue(1, 0) == VALUE.Un && _gridModel.GetValue(2, 0) == VALUE.Trois || _gridModel.GetValue(0, 0) == VALUE.Un && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Un || _gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Un && _gridModel.GetValue(2, 0) == VALUE.Un)
        {
            Debug.Log("Player 2 a castigat 1 ");
            ScorePlayer2 = ScorePlayer2 + 1;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Un && _gridModel.GetValue(1, 0) == VALUE.Un && _gridModel.GetValue(2, 0) == VALUE.Quatre || _gridModel.GetValue(0, 0) == VALUE.Un && _gridModel.GetValue(1, 0) == VALUE.Quatre && _gridModel.GetValue(2, 0) == VALUE.Un || _gridModel.GetValue(0, 0) == VALUE.Quatre && _gridModel.GetValue(1, 0) == VALUE.Un && _gridModel.GetValue(2, 0) == VALUE.Un)
        {
            Debug.Log("Player 2 a castigat 1 ");
            ScorePlayer2 = ScorePlayer2 + 1;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Un && _gridModel.GetValue(1, 0) == VALUE.Un && _gridModel.GetValue(2, 0) == VALUE.Cinq || _gridModel.GetValue(0, 0) == VALUE.Un && _gridModel.GetValue(1, 0) == VALUE.Cinq && _gridModel.GetValue(2, 0) == VALUE.Un || _gridModel.GetValue(0, 0) == VALUE.Cinq && _gridModel.GetValue(1, 0) == VALUE.Un && _gridModel.GetValue(2, 0) == VALUE.Un)
        {
            Debug.Log("Player 2 a castigat 1 ");
            ScorePlayer2 = ScorePlayer2 + 1;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Un && _gridModel.GetValue(1, 0) == VALUE.Un && _gridModel.GetValue(2, 0) == VALUE.Six || _gridModel.GetValue(0, 0) == VALUE.Un && _gridModel.GetValue(1, 0) == VALUE.Six && _gridModel.GetValue(2, 0) == VALUE.Un || _gridModel.GetValue(0, 0) == VALUE.Six && _gridModel.GetValue(1, 0) == VALUE.Un && _gridModel.GetValue(2, 0) == VALUE.Un)
        {
            Debug.Log("Player 2 a castigat 1 ");
            ScorePlayer2 = ScorePlayer2 + 1;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Deux && _gridModel.GetValue(1, 0) == VALUE.Deux && _gridModel.GetValue(2, 0) == VALUE.Un || _gridModel.GetValue(0, 0) == VALUE.Deux && _gridModel.GetValue(1, 0) == VALUE.Un && _gridModel.GetValue(2, 0) == VALUE.Deux || _gridModel.GetValue(0, 0) == VALUE.Un && _gridModel.GetValue(1, 0) == VALUE.Deux && _gridModel.GetValue(2, 0) == VALUE.Deux)
        {
            Debug.Log("Player 2 a castigat 2 ");
            ScorePlayer2 = ScorePlayer2 + 2;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Deux && _gridModel.GetValue(1, 0) == VALUE.Deux && _gridModel.GetValue(2, 0) == VALUE.Trois || _gridModel.GetValue(0, 0) == VALUE.Deux && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Deux || _gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Deux && _gridModel.GetValue(2, 0) == VALUE.Deux)
        {
            Debug.Log("Player 2 a castigat 2 ");
            ScorePlayer2 = ScorePlayer2 + 2;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Deux && _gridModel.GetValue(1, 0) == VALUE.Deux && _gridModel.GetValue(2, 0) == VALUE.Quatre || _gridModel.GetValue(0, 0) == VALUE.Deux && _gridModel.GetValue(1, 0) == VALUE.Quatre && _gridModel.GetValue(2, 0) == VALUE.Deux || _gridModel.GetValue(0, 0) == VALUE.Quatre && _gridModel.GetValue(1, 0) == VALUE.Deux && _gridModel.GetValue(2, 0) == VALUE.Deux)
        {
            Debug.Log("Player 2 a castigat 2 ");
            ScorePlayer2 = ScorePlayer2 + 2;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Deux && _gridModel.GetValue(1, 0) == VALUE.Deux && _gridModel.GetValue(2, 0) == VALUE.Cinq || _gridModel.GetValue(0, 0) == VALUE.Deux && _gridModel.GetValue(1, 0) == VALUE.Cinq && _gridModel.GetValue(2, 0) == VALUE.Deux || _gridModel.GetValue(0, 0) == VALUE.Cinq && _gridModel.GetValue(1, 0) == VALUE.Deux && _gridModel.GetValue(2, 0) == VALUE.Deux)
        {
            Debug.Log("Player 2 a castigat 2 ");
            ScorePlayer2 = ScorePlayer2 + 2;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Deux && _gridModel.GetValue(1, 0) == VALUE.Deux && _gridModel.GetValue(2, 0) == VALUE.Six || _gridModel.GetValue(0, 0) == VALUE.Deux && _gridModel.GetValue(1, 0) == VALUE.Six && _gridModel.GetValue(2, 0) == VALUE.Deux || _gridModel.GetValue(0, 0) == VALUE.Six && _gridModel.GetValue(1, 0) == VALUE.Deux && _gridModel.GetValue(2, 0) == VALUE.Deux)
        {
            Debug.Log("Player 2 a castigat 2 ");
            ScorePlayer2 = ScorePlayer2 + 2;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Un || _gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Un && _gridModel.GetValue(2, 0) == VALUE.Trois || _gridModel.GetValue(0, 0) == VALUE.Un && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Trois)
        {
            Debug.Log("Player 2 a castigat 3 ");
            ScorePlayer2 = ScorePlayer2 + 3;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Deux || _gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Deux && _gridModel.GetValue(2, 0) == VALUE.Trois || _gridModel.GetValue(0, 0) == VALUE.Deux && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Trois)
        {
            Debug.Log("Player 2 a castigat 3 ");
            ScorePlayer2 = ScorePlayer2 + 3;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Quatre || _gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Quatre && _gridModel.GetValue(2, 0) == VALUE.Trois || _gridModel.GetValue(0, 0) == VALUE.Quatre && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Trois)
        {
            Debug.Log("Player 2 a castigat 3 ");
            ScorePlayer2 = ScorePlayer2 + 3;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Cinq || _gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Cinq && _gridModel.GetValue(2, 0) == VALUE.Trois || _gridModel.GetValue(0, 0) == VALUE.Cinq && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Trois)
        {
            Debug.Log("Player 2 a castigat 3 ");
            ScorePlayer2 = ScorePlayer2 + 3;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Six || _gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Six && _gridModel.GetValue(2, 0) == VALUE.Trois || _gridModel.GetValue(0, 0) == VALUE.Six && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Trois)
        {
            Debug.Log("Player 2 a castigat 3 ");
            ScorePlayer2 = ScorePlayer2 + 3;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Quatre && _gridModel.GetValue(1, 0) == VALUE.Quatre && _gridModel.GetValue(2, 0) == VALUE.Un || _gridModel.GetValue(0, 0) == VALUE.Quatre && _gridModel.GetValue(1, 0) == VALUE.Un && _gridModel.GetValue(2, 0) == VALUE.Quatre || _gridModel.GetValue(0, 0) == VALUE.Un && _gridModel.GetValue(1, 0) == VALUE.Quatre && _gridModel.GetValue(2, 0) == VALUE.Quatre)
        {
            Debug.Log("Player 2 a castigat 4 ");
            ScorePlayer2 = ScorePlayer2 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Quatre && _gridModel.GetValue(1, 0) == VALUE.Quatre && _gridModel.GetValue(2, 0) == VALUE.Deux || _gridModel.GetValue(0, 0) == VALUE.Quatre && _gridModel.GetValue(1, 0) == VALUE.Deux && _gridModel.GetValue(2, 0) == VALUE.Quatre || _gridModel.GetValue(0, 0) == VALUE.Deux && _gridModel.GetValue(1, 0) == VALUE.Quatre && _gridModel.GetValue(2, 0) == VALUE.Quatre)
        {
            Debug.Log("Player 2 a castigat 4 ");
            ScorePlayer2 = ScorePlayer2 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Quatre && _gridModel.GetValue(1, 0) == VALUE.Quatre && _gridModel.GetValue(2, 0) == VALUE.Trois || _gridModel.GetValue(0, 0) == VALUE.Quatre && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Quatre || _gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Quatre && _gridModel.GetValue(2, 0) == VALUE.Quatre)
        {
            Debug.Log("Player 2 a castigat 4 ");
            ScorePlayer2 = ScorePlayer2 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Quatre && _gridModel.GetValue(1, 0) == VALUE.Quatre && _gridModel.GetValue(2, 0) == VALUE.Cinq || _gridModel.GetValue(0, 0) == VALUE.Quatre && _gridModel.GetValue(1, 0) == VALUE.Cinq && _gridModel.GetValue(2, 0) == VALUE.Quatre || _gridModel.GetValue(0, 0) == VALUE.Cinq && _gridModel.GetValue(1, 0) == VALUE.Quatre && _gridModel.GetValue(2, 0) == VALUE.Quatre)
        {
            Debug.Log("Player 2 a castigat 4 ");
            ScorePlayer2 = ScorePlayer2 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Quatre && _gridModel.GetValue(1, 0) == VALUE.Quatre && _gridModel.GetValue(2, 0) == VALUE.Six || _gridModel.GetValue(0, 0) == VALUE.Quatre && _gridModel.GetValue(1, 0) == VALUE.Six && _gridModel.GetValue(2, 0) == VALUE.Quatre || _gridModel.GetValue(0, 0) == VALUE.Six && _gridModel.GetValue(1, 0) == VALUE.Quatre && _gridModel.GetValue(2, 0) == VALUE.Quatre)
        {
            Debug.Log("Player 2 a castigat 4 ");
            ScorePlayer2 = ScorePlayer2 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Cinq && _gridModel.GetValue(1, 0) == VALUE.Cinq && _gridModel.GetValue(2, 0) == VALUE.Un || _gridModel.GetValue(0, 0) == VALUE.Cinq && _gridModel.GetValue(1, 0) == VALUE.Un && _gridModel.GetValue(2, 0) == VALUE.Cinq || _gridModel.GetValue(0, 0) == VALUE.Un && _gridModel.GetValue(1, 0) == VALUE.Cinq && _gridModel.GetValue(2, 0) == VALUE.Cinq)
        {
            Debug.Log("Player 2 a castigat 5 ");
            ScorePlayer2 = ScorePlayer2 + 5;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Cinq && _gridModel.GetValue(1, 0) == VALUE.Cinq && _gridModel.GetValue(2, 0) == VALUE.Deux || _gridModel.GetValue(0, 0) == VALUE.Cinq && _gridModel.GetValue(1, 0) == VALUE.Deux && _gridModel.GetValue(2, 0) == VALUE.Cinq || _gridModel.GetValue(0, 0) == VALUE.Deux && _gridModel.GetValue(1, 0) == VALUE.Cinq && _gridModel.GetValue(2, 0) == VALUE.Cinq)
        {
            Debug.Log("Player 2 a castigat 5 ");
            ScorePlayer2 = ScorePlayer2 + 5;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Cinq && _gridModel.GetValue(1, 0) == VALUE.Cinq && _gridModel.GetValue(2, 0) == VALUE.Trois || _gridModel.GetValue(0, 0) == VALUE.Cinq && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Cinq || _gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Cinq && _gridModel.GetValue(2, 0) == VALUE.Cinq)
        {
            Debug.Log("Player 2 a castigat 5 ");
            ScorePlayer2 = ScorePlayer2 + 5;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Cinq && _gridModel.GetValue(1, 0) == VALUE.Cinq && _gridModel.GetValue(2, 0) == VALUE.Quatre || _gridModel.GetValue(0, 0) == VALUE.Cinq && _gridModel.GetValue(1, 0) == VALUE.Quatre && _gridModel.GetValue(2, 0) == VALUE.Cinq || _gridModel.GetValue(0, 0) == VALUE.Quatre && _gridModel.GetValue(1, 0) == VALUE.Cinq && _gridModel.GetValue(2, 0) == VALUE.Cinq)
        {
            Debug.Log("Player 2 a castigat 5 ");
            ScorePlayer2 = ScorePlayer2 + 5;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Cinq && _gridModel.GetValue(1, 0) == VALUE.Cinq && _gridModel.GetValue(2, 0) == VALUE.Six || _gridModel.GetValue(0, 0) == VALUE.Cinq && _gridModel.GetValue(1, 0) == VALUE.Six && _gridModel.GetValue(2, 0) == VALUE.Cinq || _gridModel.GetValue(0, 0) == VALUE.Six && _gridModel.GetValue(1, 0) == VALUE.Cinq && _gridModel.GetValue(2, 0) == VALUE.Cinq)
        {
            Debug.Log("Player 2 a castigat 5 ");
            ScorePlayer2 = ScorePlayer2 + 5;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Six && _gridModel.GetValue(1, 0) == VALUE.Six && _gridModel.GetValue(2, 0) == VALUE.Un || _gridModel.GetValue(0, 0) == VALUE.Six && _gridModel.GetValue(1, 0) == VALUE.Un && _gridModel.GetValue(2, 0) == VALUE.Six || _gridModel.GetValue(0, 0) == VALUE.Un && _gridModel.GetValue(1, 0) == VALUE.Six && _gridModel.GetValue(2, 0) == VALUE.Six)
        {
            Debug.Log("Player 2 a castigat 6 ");
            ScorePlayer2 = ScorePlayer2 + 6;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Six && _gridModel.GetValue(1, 0) == VALUE.Six && _gridModel.GetValue(2, 0) == VALUE.Deux || _gridModel.GetValue(0, 0) == VALUE.Six && _gridModel.GetValue(1, 0) == VALUE.Deux && _gridModel.GetValue(2, 0) == VALUE.Six || _gridModel.GetValue(0, 0) == VALUE.Deux && _gridModel.GetValue(1, 0) == VALUE.Six && _gridModel.GetValue(2, 0) == VALUE.Six)
        {
            Debug.Log("Player 2 a castigat 6 ");
            ScorePlayer2 = ScorePlayer2 + 6;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Six && _gridModel.GetValue(1, 0) == VALUE.Six && _gridModel.GetValue(2, 0) == VALUE.Trois || _gridModel.GetValue(0, 0) == VALUE.Six && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Six || _gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Six && _gridModel.GetValue(2, 0) == VALUE.Six)
        {
            Debug.Log("Player 2 a castigat 6 ");
            ScorePlayer2 = ScorePlayer2 + 6;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Six && _gridModel.GetValue(1, 0) == VALUE.Six && _gridModel.GetValue(2, 0) == VALUE.Quatre || _gridModel.GetValue(0, 0) == VALUE.Six && _gridModel.GetValue(1, 0) == VALUE.Quatre && _gridModel.GetValue(2, 0) == VALUE.Six || _gridModel.GetValue(0, 0) == VALUE.Quatre && _gridModel.GetValue(1, 0) == VALUE.Six && _gridModel.GetValue(2, 0) == VALUE.Six)
        {
            Debug.Log("Player 2 a castigat 6 ");
            ScorePlayer2 = ScorePlayer2 + 6;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Six && _gridModel.GetValue(1, 0) == VALUE.Six && _gridModel.GetValue(2, 0) == VALUE.Cinq || _gridModel.GetValue(0, 0) == VALUE.Six && _gridModel.GetValue(1, 0) == VALUE.Cinq && _gridModel.GetValue(2, 0) == VALUE.Six || _gridModel.GetValue(0, 0) == VALUE.Cinq && _gridModel.GetValue(1, 0) == VALUE.Six && _gridModel.GetValue(2, 0) == VALUE.Six)
        {
            Debug.Log("Player 2 a castigat 6 ");
            ScorePlayer2 = ScorePlayer2 + 6;
        }
    }


    public void Player2Suite()
    {
        if (_gridModel.GetValue(0, 0) == VALUE.Un && _gridModel.GetValue(1, 0) == VALUE.Deux && _gridModel.GetValue(2, 0) == VALUE.Trois )
        {
            Debug.Log("Player 2 a castigat 4 ");
            ScorePlayer2 = ScorePlayer2 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Un && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Deux )
        {
            Debug.Log("Player 2 a castigat 4 ");
            ScorePlayer2 = ScorePlayer2 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Deux && _gridModel.GetValue(1, 0) == VALUE.Un  && _gridModel.GetValue(2, 0) == VALUE.Trois)
        {
            Debug.Log("Player 2 a castigat 4 ");
            ScorePlayer2 = ScorePlayer2 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Deux && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Un)
        {
            Debug.Log("Player 2 a castigat 4 ");
            ScorePlayer2 = ScorePlayer2 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Un && _gridModel.GetValue(2, 0) == VALUE.Deux)
        {
            Debug.Log("Player 2 a castigat 4 ");
            ScorePlayer2 = ScorePlayer2 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Deux && _gridModel.GetValue(2, 0) == VALUE.Un)
        {
            Debug.Log("Player 2 a castigat 4 ");
            ScorePlayer2 = ScorePlayer2 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Quatre && _gridModel.GetValue(2, 0) == VALUE.Cinq)
        {
            Debug.Log("Player 2 a castigat 4 ");
            ScorePlayer2 = ScorePlayer2 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Cinq && _gridModel.GetValue(2, 0) == VALUE.Quatre)
        {
            Debug.Log("Player 2 a castigat 4 ");
            ScorePlayer2 = ScorePlayer2 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Quatre && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Cinq)
        {
            Debug.Log("Player 2 a castigat 4 ");
            ScorePlayer2 = ScorePlayer2 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Quatre && _gridModel.GetValue(1, 0) == VALUE.Cinq && _gridModel.GetValue(2, 0) == VALUE.Trois)
        {
            Debug.Log("Player 2 a castigat 4 ");
            ScorePlayer2 = ScorePlayer2 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Cinq && _gridModel.GetValue(1, 0) == VALUE.Quatre && _gridModel.GetValue(2, 0) == VALUE.Trois)
        {
            Debug.Log("Player 2 a castigat 4 ");
            ScorePlayer2 = ScorePlayer2 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Cinq && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Quatre)
        {
            Debug.Log("Player 2 a castigat 4 ");
            ScorePlayer2 = ScorePlayer2 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Quatre && _gridModel.GetValue(1, 0) == VALUE.Cinq && _gridModel.GetValue(2, 0) == VALUE.Six)
        {
            Debug.Log("Player 2 a castigat 4 ");
            ScorePlayer2 = ScorePlayer2 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Quatre && _gridModel.GetValue(1, 0) == VALUE.Six && _gridModel.GetValue(2, 0) == VALUE.Cinq)
        {
            Debug.Log("Player 2 a castigat 4 ");
            ScorePlayer2 = ScorePlayer2 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Cinq && _gridModel.GetValue(1, 0) == VALUE.Quatre && _gridModel.GetValue(2, 0) == VALUE.Six)
        {
            Debug.Log("Player 2 a castigat 4 ");
            ScorePlayer2 = ScorePlayer2 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Cinq && _gridModel.GetValue(1, 0) == VALUE.Six && _gridModel.GetValue(2, 0) == VALUE.Quatre)
        {
            Debug.Log("Player 2 a castigat 4 ");
            ScorePlayer2 = ScorePlayer2 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Six && _gridModel.GetValue(1, 0) == VALUE.Cinq && _gridModel.GetValue(2, 0) == VALUE.Quatre)
        {
            Debug.Log("Player 2 a castigat 4 ");
            ScorePlayer2 = ScorePlayer2 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Six && _gridModel.GetValue(1, 0) == VALUE.Quatre && _gridModel.GetValue(2, 0) == VALUE.Cinq)
        {
            Debug.Log("Player 2 a castigat 4 ");
            ScorePlayer2 = ScorePlayer2 + 4;
        }
    }

    public void Player1Suite()
    {
        if (_gridModel.GetValue(0, 0) == VALUE.Un && _gridModel.GetValue(1, 0) == VALUE.Deux && _gridModel.GetValue(2, 0) == VALUE.Trois)
        {
            Debug.Log("Player 1 a castigat 4 ");
            ScorePlayer1 = ScorePlayer1 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Un && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Deux)
        {
            Debug.Log("Player 1 a castigat 4 ");
            ScorePlayer1 = ScorePlayer1 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Deux && _gridModel.GetValue(1, 0) == VALUE.Un && _gridModel.GetValue(2, 0) == VALUE.Trois)
        {
            Debug.Log("Player 1 a castigat 4 ");
            ScorePlayer1 = ScorePlayer1 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Deux && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Un)
        {
            Debug.Log("Player 1 a castigat 4 ");
            ScorePlayer1 = ScorePlayer1 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Un && _gridModel.GetValue(2, 0) == VALUE.Deux)
        {
            Debug.Log("Player 1 a castigat 4 ");
            ScorePlayer1 = ScorePlayer1 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Deux && _gridModel.GetValue(2, 0) == VALUE.Un)
        {
            Debug.Log("Player 1 a castigat 4 ");
            ScorePlayer1 = ScorePlayer1 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Quatre && _gridModel.GetValue(2, 0) == VALUE.Cinq)
        {
            Debug.Log("Player 1 a castigat 4 ");
            ScorePlayer1 = ScorePlayer1 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Cinq && _gridModel.GetValue(2, 0) == VALUE.Quatre)
        {
            Debug.Log("Player 1 a castigat 4 ");
            ScorePlayer1 = ScorePlayer1 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Quatre && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Cinq)
        {
            Debug.Log("Player 1 a castigat 4 ");
            ScorePlayer1 = ScorePlayer1 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Quatre && _gridModel.GetValue(1, 0) == VALUE.Cinq && _gridModel.GetValue(2, 0) == VALUE.Trois)
        {
            Debug.Log("Player 1 a castigat 4 ");
            ScorePlayer1 = ScorePlayer1 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Cinq && _gridModel.GetValue(1, 0) == VALUE.Quatre && _gridModel.GetValue(2, 0) == VALUE.Trois)
        {
            Debug.Log("Player 1 a castigat 4 ");
            ScorePlayer1 = ScorePlayer1 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Cinq && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Quatre)
        {
            Debug.Log("Player 1 a castigat 4 ");
            ScorePlayer1 = ScorePlayer1 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Quatre && _gridModel.GetValue(1, 0) == VALUE.Cinq && _gridModel.GetValue(2, 0) == VALUE.Six)
        {
            Debug.Log("Player 1 a castigat 4 ");
            ScorePlayer1 = ScorePlayer1 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Quatre && _gridModel.GetValue(1, 0) == VALUE.Six && _gridModel.GetValue(2, 0) == VALUE.Cinq)
        {
            Debug.Log("Player 1 a castigat 4 ");
            ScorePlayer1 = ScorePlayer1 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Cinq && _gridModel.GetValue(1, 0) == VALUE.Quatre && _gridModel.GetValue(2, 0) == VALUE.Six)
        {
            Debug.Log("Player 1 a castigat 4 ");
            ScorePlayer1 = ScorePlayer1 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Cinq && _gridModel.GetValue(1, 0) == VALUE.Six && _gridModel.GetValue(2, 0) == VALUE.Quatre)
        {
            Debug.Log("Player 1 a castigat 4 ");
            ScorePlayer1 = ScorePlayer1 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Six && _gridModel.GetValue(1, 0) == VALUE.Cinq && _gridModel.GetValue(2, 0) == VALUE.Quatre)
        {
            Debug.Log("Player 1 a castigat 4 ");
            ScorePlayer1 = ScorePlayer1 + 4;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Six && _gridModel.GetValue(1, 0) == VALUE.Quatre && _gridModel.GetValue(2, 0) == VALUE.Cinq)
        {
            Debug.Log("Player 1 a castigat 4 ");
            ScorePlayer1 = ScorePlayer1 + 4;
        }
    }

    public void Player2Cochon()
    {

        if (_gridModel.GetValue(0, 0) == VALUE.Un && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Six)
        {
            Debug.Log("Player 2 a castigat 20 ");
            ScorePlayer2 = ScorePlayer2 + 20;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Un && _gridModel.GetValue(1, 0) == VALUE.Six && _gridModel.GetValue(2, 0) == VALUE.Trois)
        {
            Debug.Log("Player 2 a castigat 20 ");
            ScorePlayer2 = ScorePlayer2 + 20;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Six && _gridModel.GetValue(1, 0) == VALUE.Un && _gridModel.GetValue(2, 0) == VALUE.Trois)
        {
            Debug.Log("Player 2 a castigat 20 ");
            ScorePlayer2 = ScorePlayer2 + 20;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Six && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Un)
        {
            Debug.Log("Player 2 a castigat 20 ");
            ScorePlayer2 = ScorePlayer2 + 20;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Un && _gridModel.GetValue(2, 0) == VALUE.Six)
        {
            Debug.Log("Player 2 a castigat 20 ");
            ScorePlayer2 = ScorePlayer2 + 20;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Six && _gridModel.GetValue(2, 0) == VALUE.Un)
        {
            Debug.Log("Player 2 a castigat 20 ");
            ScorePlayer2 = ScorePlayer2 + 20;
        }
    }

    public void Player1Cochon()
    {

        if (_gridModel.GetValue(0, 0) == VALUE.Un && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Six)
        {
            Debug.Log("Player 1 a castigat 20 ");
            ScorePlayer1 = ScorePlayer1 + 20;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Un && _gridModel.GetValue(1, 0) == VALUE.Six && _gridModel.GetValue(2, 0) == VALUE.Trois)
        {
            Debug.Log("Player 1 a castigat 20 ");
            ScorePlayer1 = ScorePlayer1 + 20;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Six && _gridModel.GetValue(1, 0) == VALUE.Un && _gridModel.GetValue(2, 0) == VALUE.Trois)
        {
            Debug.Log("Player 1 a castigat 20 ");
            ScorePlayer1 = ScorePlayer1 + 20;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Six && _gridModel.GetValue(1, 0) == VALUE.Trois && _gridModel.GetValue(2, 0) == VALUE.Un)
        {
            Debug.Log("Player 1 a castigat 20 ");
            ScorePlayer1 = ScorePlayer1 + 20;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Un && _gridModel.GetValue(2, 0) == VALUE.Six)
        {
            Debug.Log("Player 1 a castigat 20 ");
            ScorePlayer1 = ScorePlayer1 + 20;
        }
        else if (_gridModel.GetValue(0, 0) == VALUE.Trois && _gridModel.GetValue(1, 0) == VALUE.Six && _gridModel.GetValue(2, 0) == VALUE.Un)
        {
            Debug.Log("Player 1 a castigat 20 ");
            ScorePlayer1 = ScorePlayer1 + 20;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
  
   
   
}
