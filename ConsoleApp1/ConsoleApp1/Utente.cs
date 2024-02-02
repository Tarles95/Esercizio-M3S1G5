using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Utente
    {   //Dichairazione 
        public static string nome;
        public static string cognome;
        public static string dataNascita;
        public static string residenza;
        public static string codiceFiscale;
        public static char sesso;
        public static int redditoAnnuale;



        private static string ToUpperFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return char.ToUpper(input[0]) + input.Substring(1);
        }
        //Avvio Console
        public static void Start()

        //Richiesta di tutti i dati, eventualmente convertiti se necessario
        {
            Console.WriteLine("Sei pronto a pagare le tasse?");

            Console.WriteLine("\nInserisci il tuo nome:");
            Utente.nome = Console.ReadLine();

            Console.WriteLine("\nInserisci il tuo cognnome:");
            Utente.cognome = Console.ReadLine();
            Console.WriteLine("\nInserisci la tua data di nascita:           (GG MM AAAA)");
            Utente.dataNascita = Console.ReadLine();

            Console.WriteLine("\nInserisci il tuo comune di residenza:");
            Utente.residenza = Console.ReadLine();

            Console.WriteLine("\nInserisci il tuo codice fiscale:");
            Utente.codiceFiscale = Console.ReadLine().ToUpper();

            if (Utente.codiceFiscale.Length < 16)
            {
                Console.WriteLine("Errore: Il codice fiscale deve avere almeno 16 caratteri.");
                return;
            }

            Console.WriteLine("\n'Sei maschio o femmina?' (M/F):");
            Utente.sesso = Convert.ToChar(Console.ReadLine());

            Console.WriteLine("\nInserisci il tuo reddito annuale:");
            Utente.redditoAnnuale = Convert.ToInt32(Console.ReadLine());


            //Stampa dei dati forniti dall'utente
            Console.WriteLine($"\n======RESOCONTO UTENTE=======\n" +
                $"Contribuente: {ToUpperFirstLetter(Utente.nome)} {ToUpperFirstLetter(Utente.cognome)}\nNato il: {Utente.dataNascita}({Utente.sesso})\nResidente a: {ToUpperFirstLetter(Utente.residenza)}\nCodice fiscale: [{Utente.codiceFiscale}]" +
                $"\nReddito annuale dichiarato: {Utente.redditoAnnuale} euro ");
            Console.ReadLine();
        }
        //Avvio funzione per calcolare dopo l'aliquota e le imposte dovute 
            public static void Conto()
            {

                switch (Utente.redditoAnnuale)
                {
                    case int redditoAnnuale when redditoAnnuale < 15000: 
                        int newReddito = redditoAnnuale;
                        double amount = newReddito * 0.27 + 3450;

                        Console.WriteLine($"Devi pagare {amount} euro.");
                        break;

                    case int redditoAnnuale when redditoAnnuale > 15000://Confrontiamo il valore inserito con gli scaglioni
                        int newReddito0 = redditoAnnuale - 15000;//Ricaviamo la parte eccedente
                        double amount0 = newReddito0 * 0.27 + 3450; //Sommiamo la parte eccedente con la sua aliquota e l'imposta dovuta

                        Console.WriteLine($"Devi pagare {amount0} euro.");//Inseriamo l'ammontare da pagare
                        break;

                    case int redditoAnnuale when redditoAnnuale > +28000:
                        int newReddito1 = redditoAnnuale - 15000;
                        double amount1 = newReddito1 * 0.38 + 6960;

                        Console.WriteLine($"Devi pagare {amount1} euro.");
                        break;

                    case int redditoAnnuale when redditoAnnuale > 55000:
                        int newReddito2 = redditoAnnuale - 55000;
                        double amount2 = newReddito2 * 0.41 + 17220;

                        Console.WriteLine($"Devi pagare {amount2} euro.");
                        break;

                    case int redditoAnnuale when redditoAnnuale > 55000:
                        int newReddito3 = redditoAnnuale - 55000;
                        double amount3 = newReddito3 * 0.43 + 25420;

                        Console.WriteLine($"Devi pagare {amount3} euro.");
                        break;

                // Altri casi possono essere aggiunti secondo necessità
                default:
                        Console.WriteLine("Non hai inserito valori ammessi");
                        break;
                }
            Console.ReadLine();
        }
            
        }
    }


