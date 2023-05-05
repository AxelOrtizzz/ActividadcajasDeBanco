//Funcion Principal
int[] retiros= null;
int opcion = Menu();
    

while (opcion != 0){
        
    Console.WriteLine($"Opcion numero {opcion} elegida");
    if(opcion == 1){
       retiros = Retiros();
    }
    if(opcion == 2){
        if (retiros != null)
        {
            Billetes(retiros);
        }
        else
        {
            Console.WriteLine("No hay retiros ingresados. Por favor, elija la opción 1 para ingresar retiros.");
        }   
    } 
    Console.WriteLine("\nPresiona 'Enter' para continuar...");
    Console.ReadLine(); 
    opcion = Menu();    
}
// Fin Funcion Principal

//Inicio Funcion Menu
    int Menu() {
        Console.WriteLine("---------------------- Banco CDIS -----------------------");
        Console.WriteLine("1. Ingrese la cantidad de retiros hechos por los usuarios");
        Console.WriteLine("2. Revisar la cantidad entregada de billetes y monedas.");        
        Console.WriteLine("Ingrese la opcion:");
        return opcion = int.Parse(Console.ReadLine());
    }
//Fin Funcion Menu 50000

// Inicion Funcion Retiros
    static int[] Retiros(){
        int cantidadRetiros = 0;

        while(cantidadRetiros > 10 || cantidadRetiros == 0){
            Console.WriteLine("¿Cuantos retiros se hicieron (maximo 10)?");
            cantidadRetiros = int.Parse(Console.ReadLine());
        }

        int[] retiros = new int[cantidadRetiros];

        for (int i = 0; i < retiros.Length; i++){    
            Console.WriteLine($"Ingrese la cantidad del retiro #{i+1}:");
            retiros[i] = int.Parse(Console.ReadLine());
            if(50000 <= retiros[i] || retiros[i]<=0){
                Console.WriteLine("!SU INGRESO DEBE DE SER EN UN RANGO DE 0 y 50,000 PESOS¡");
                i=i-1;
            }
        }
        return retiros;
    }
// Fin  Funcion Retiros


    static void Billetes(int[] retiros)
    {
    // Código para manipular el arreglo y realizar cálculos
        int[] numeros = retiros.ToArray();
        int[] denominaciones = { 500, 200, 100, 50, 20, 10, 5, 1 }; // Valores de los billetes en orden descendente
        int[] cantidadBilletes = new int[denominaciones.Length];
        int totalBilletes = 0;
        int totalMonedas = 0;
        for(int i = 0; i < numeros.Length; i++){ //Se recorre el arreglo para cada retiro
        
            Console.WriteLine($"\r\nRetiro #{i+1} ");
            Console.WriteLine($"Cantidad: {numeros[i]}\r\n");

            for (int j = 0; j < denominaciones.Length; j++){
                cantidadBilletes[j] = numeros[i] / denominaciones[j]; // Calcular la cantidad de billetes de la denominación actual
                numeros[i] = numeros[i] % denominaciones[j]; // Obtener el resto después de obtener los billetes de la denominación actual
            }

            for (int j = 0; j < denominaciones.Length; j++){
                if(denominaciones[j]<=10){  // si la denominacion actual es menor a 10, significa que es moneda                
                    totalMonedas = totalMonedas + cantidadBilletes[j]; // Calcular el total de monedas 
                }else{
                    totalBilletes = totalBilletes + cantidadBilletes[j]; //Calcular el total de monedas
                }   
            } 
        Console.WriteLine("Billetes entregados:  " + totalBilletes);
        Console.WriteLine("Monedas entregadas: " + totalMonedas);
        totalMonedas = 0;
        totalBilletes = 0;
        }
    }
        /* 
    5,238
    5, 238 / 500 = 10 billetes
    238 / 200 = 2 billetes
    38 / 100 = 0 biletes
    38 / 50 = 0 billetes
    38 / 20 = 1 billete
    18 / 10 = 1 moneda
    8 / 5 = 1 moneda
    3 / 1 = 3 monedas
 */