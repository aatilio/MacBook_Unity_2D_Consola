using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ejecut : MonoBehaviour
{
    Dificultad dificultadElegida;
    Pantalla PantallaActual = Pantalla.Menu;
    //variable importante
    string passwordActual;
    string entidad = " ";
    //variables de control
    int intentosHelp = 0;
    //Arrays
    string[] passwordBasico = { "director", "profesor", "alumno", "lonchera", "cartuchera", "mochila", "cartuchera" };
    string[] passwordModerado = { "cliente", "gerente", "credito", "tarjeta" };
    string[] passwordDificil = { "presidente", "congreso", "ley0001", "burocrota" };
    //enum
    enum Dificultad { Cero, Basico, Moderado, Dificil };
    enum Pantalla { Terminal, Menu, Password, Victoria, Derrota };

    // Start is called before the first frame update
    void Start()
    {
        MostrarMenuTerminal();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void MostrarMenuTerminal()
    {
        Terminal.EscribirLinea("Escoja uno de los niveles: ");
        Terminal.EscribirLinea("1 > NIVEL BASICO");
        Terminal.EscribirLinea("2 > NIVEL MODERADO");
        Terminal.EscribirLinea("3 > NIVEL DIFICIL\n");
        //OnUserInput();
    }

    void OnUserInput(string mensaje)
    {
        if (mensaje == "menu")
        {
            borrarTodoyMostrarMenu();
        }
        else if (mensaje == "clear")
        {
            borrarTodo();
        }
        else
        {
            if (PantallaActual == Pantalla.Menu)
            {
                procesarImputEnMenu(mensaje);
            }
            else if (PantallaActual == Pantalla.Password)
            {
                ProcesarInputEnPassword(mensaje);
            }
            else if (PantallaActual == Pantalla.Victoria)
            {
                ProcesarInputEnVictoria(mensaje);
            }
            else
            {
                Terminal.EscribirLinea("is not recognized as an internal or external command.");
            }
        }
    }

    void borrarTodoyMostrarMenu()
    {
        Terminal.BorrarPantalla();
        MostrarMenuTerminal();
        PantallaActual = Pantalla.Menu;
        dificultadElegida = Dificultad.Basico;
        passwordActual = "321";
        //pantallaActual = 0;
    }

    void borrarTodo()
    {
        Terminal.BorrarPantalla();
        PantallaActual = Pantalla.Terminal;
        dificultadElegida = Dificultad.Cero;
        passwordActual = "1";
    }

    void procesarImputEnMenu(string mensaje)
    {
        if (PantallaActual == Pantalla.Menu)
        {
            //print(passwordBasico.Length);


            switch (mensaje)
            {
                case "1":
                    //pantallaActual = 1;
                    dificultadElegida = Dificultad.Basico;
                    PantallaActual = Pantalla.Password;
                    intentosHelp = 3; 
                    entidad = " ESCUELA ";
                    //int passB = Random.Range(0, passwordBasico.Length);
                    //passwordActual = passwordBasico[passB];
                    passwordActual = passwordBasico[Random.Range(0, passwordBasico.Length)];
                    Terminal.BorrarPantalla();
                    Terminal.EscribirLinea("\nB_Ingrese password;\t\t Pista ->\t" + passwordActual.Anagram());
                    break;
                case "2":
                    //pantallaActual = 2;
                    dificultadElegida = Dificultad.Moderado;
                    PantallaActual = Pantalla.Password;
                    intentosHelp = 2; 
                    entidad = " BANCO ";
                    //int passM = Random.Range(0, passwordModerado.Length);
                    //passwordActual = passwordModerado[passM];
                    passwordActual = passwordModerado[Random.Range(0, passwordModerado.Length)];
                    Terminal.BorrarPantalla();
                    Terminal.EscribirLinea("\nM_Ingresa ingrese password;\t\t Pista ->\t" + passwordActual.Anagram());
                    break;
                case "3":
                    //pantallaActual = 3;
                    dificultadElegida = Dificultad.Dificil;
                    PantallaActual = Pantalla.Password;
                    intentosHelp = 1; 
                    entidad = " GOVIERNO ";
                    //int passD = Random.Range(0, passwordDificil.Length);
                    //passwordActual = passwordDificil[passD];
                    passwordActual = passwordDificil[Random.Range(0, passwordDificil.Length)];
                    Terminal.BorrarPantalla();
                    Terminal.EscribirLinea("\nD_Ingrese password;\t\t Pista ->\t" + passwordActual.Anagram());
                    break;
                default:
                    Terminal.EscribirLinea("ERROR...Ud. eligio un comando no establesido...Intentelo de nuevo...");
                    break;
            }
            /*
            if (mensaje == "1")
            {
                Terminal.EscribirLinea("Ud. eligio la Opcion 1...");
                //pantallaActual = 1;
                dificultadElegida = Dificultad.Basico;
                PantallaActual = Pantalla.Password;
                passwordActual = passwordBasico[2];
            }
            else if (mensaje == "2")
            {
                Terminal.EscribirLinea("Ud. eligio la Opcion 2...");
                //pantallaActual = 2;
                dificultadElegida = Dificultad.Moderado;
                PantallaActual = Pantalla.Victoria;
                passwordActual = passwordModerado[2];
            }
            else if (mensaje == "3")
            {
                Terminal.EscribirLinea("Ud. eligio la Opcion 3...");
                //pantallaActual = 3;
                dificultadElegida = Dificultad.Dificil;
                PantallaActual = Pantalla.Derrota;
                passwordActual = passwordDificil[2];
            }
            else if (mensaje == "caer")
            {
                Terminal.EscribirLinea("La Gerra nunca es buena...");
            }
            else
            {
                Terminal.EscribirLinea("ERROR...Ud. eligio una Opcion Incorrecta...Prueba con otra...");
            }*/
        }
    }

    void ProcesarInputEnPassword(string mensaje)
    {
        if (mensaje == passwordActual)
        {
            Terminal.EscribirLinea("Password corecto!!!...Inicio de secion aceptado");
            PantallaActual = Pantalla.Victoria;
        }
        else
        {
            Terminal.EscribirLinea("Password incorecto...Intentelo de nuevo...");
            PantallaActual = Pantalla.Password;
        }
    }
    void ProcesarInputEnVictoria(string mensaje)
    {
        
        if (mensaje == "copy database")
        {
            Terminal.EscribirLinea("Entidad " + entidad);
            Terminal.EscribirLinea("Datos copiados al ■ 10%");
            Terminal.EscribirLinea("Datos copiados al ■■■ 30%");
            Terminal.EscribirLinea("Datos copiados al ■■■■■■ 60%");
            Terminal.EscribirLinea("Datos copiados al ■■■■■■■■■■ 100%");
            PantallaActual = Pantalla.Menu;
        }
        else if (mensaje != "copy database" && intentosHelp == 0)
        {
            borrarTodo();
            Terminal.EscribirLinea(intentosHelp + " Intentos intentos restantes. Bloqueado!!!");
            PantallaActual = Pantalla.Menu;
        }
        else
        {
            Terminal.EscribirLinea("Error | Comando incorecto \t\t intentos restantes " + intentosHelp);
            PantallaActual = Pantalla.Victoria;
            intentosHelp--;
        }
    }
}
