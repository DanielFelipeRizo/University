using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqSnippets
{

    public class Snippets
    {
        static public void BasicLinQ()
        {
            string[] cars =
            {
                "Reault twingo",
                "Fiat punto",
                "Renault clio",
                "Audi A5",
                "Mazda 3",
                "Aveo Gt"
            };

            //1. select * from cars
            var carList = from car in cars select car;

            foreach (var car in carList)
            {
                Console.WriteLine(car);
            }
            //2. select * from car where car in 'Audi'
            var audiList = from car in carList where car.Contains("Audi") select car;

            foreach (var audi in audiList)
            {
                Console.WriteLine(audi);
            }
        }

        public static void LinqNumbers()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var numberList = numbers.Select(num => num * 3)//cada numero * 3
                .Where(num => num != 9)//todos menos el 9
                .OrderBy(num => num);//ordenar ascendente

        }

        public static void SearchExamples()
        {
            List<string> textList = new List<string> { "a", "bc", "ec", "d", "e", "f", "c" };

            //primer elemento de la lista
            var first = textList.First();

            //primer elemento con letra 'c'
            var cText = textList.First(text => text.Equals("c"));

            //primer elemento que contenga la e
            var eText = textList.First(text => text.Contains("e"));

            //primer elemento que contenga la 'z' o sino valor por defecto
            var firstOrDefaultText = textList.FirstOrDefault(text => text.Contains("z"));

            //ultimo elemento que contenga la 'z' o sino valor por defecto
            var lastOrDefaultText = textList.LastOrDefault(text => text.Contains("z"));

            //lista con solo valores unicos
            var uniqueTexts = textList.Single();
            //lista con solo valores unicos o sino valor por defecto
            var uniqueOrDefaultTexts = textList.SingleOrDefault();

            int[] evenNumbers = { 0, 2, 4, 6, 8 };
            int[] otherEvenNumbers = { 0, 2, 6, 10 };

            //obtener los numeros que no se repiten entre dos listas
            var myEvenNumbers = evenNumbers.Except(otherEvenNumbers);//4, 8, 10

        }

        public static void MultipleSelects()
        {
            string[] myOptions = { "opcion 1, text 1", "opcion 2, text 2", "opcion 3, text 3" };
            //multiple select
            var myOptionSelection = myOptions.SelectMany(option => option.Split(","));
            
            var enterprises = new[]
            {
                new Enterprise()
                {
                    id = 1,
                    name = "Enterprise 1",
                    employees = new[]
                    {
                        new Employee()
                        {
                        Id =1,
                        Name = "abc",
                        Email = "abc@mail.com",
                        Salary = 3000
                        },
                        new Employee()
                        {
                            Id =2,
                            Name = "pepe",
                            Email = "pepe@mail.com",
                            Salary = 2000
                        },
                        new Employee()
                        {
                            Id =3,
                            Name = "juan",
                            Email = "juan@mail.com",
                            Salary = 3300
                        }

                    }

                },

                new Enterprise()
                {
                    id = 2,
                    name = "Enterprise 2",
                    employees = new[]
                    {
                        new Employee()
                        {
                        Id =4,
                        Name = "ana",
                        Email = "ana@mail.com",
                        Salary = 3200
                        },
                        new Employee()
                        {
                            Id =5,
                            Name = "lana",
                            Email = "lana@mail.com",
                            Salary = 4000
                        },
                        new Employee()
                        {
                            Id =6,
                            Name = "juana",
                            Email = "juana@mail.com",
                            Salary = 3500
                        }

                    }

                }

            };

            //obtener empleados de todas las empresas
            var employeeList = enterprises.SelectMany(enterprise => enterprise.employees);

            //saber si una lista esta vacia
            bool hasEnterprises = enterprises.Any();

            //saber si lista de empleados esta vacia
            bool hasEmployees = enterprises.Any(enterprise => enterprise.employees.Any());

            //todas las empresas tienen al menos un empleado con salario >= 1000
            bool hasEmployeeSalaryMoreThanOrEqual1000 = enterprises.Any(enterprise => enterprise.employees
            .Any(employee => employee.Salary >= 1000));

        }

        public static void linqCollections()
        {
            var firstList = new List<string>() {"a", "b", "c"};
            var secontList = new List<string>() {"a", "c", "d" };

            //inner join
            var commonResult = from elementL1 in firstList 
                               join elementL2 in secontList on elementL1 equals elementL2
                               select new {elementL1, elementL2};
            
            //otra forma del mismo inner join
            var commonResult2 = firstList.Join(secontList, element1 => element1, element2 => element2,
                (element1, element2) => new {element1, element2});

            //outer join - left
            var leftOuterJoin = from elementL1 in firstList
                                join elementL2 in secontList
                                on elementL1 equals elementL2   //join normal hasta aca
                                into tempList    //guardar el inner join en lista temporal
                                from tempElement in tempList.DefaultIfEmpty()   //valida que lista no este vacia
                                where elementL1 != tempElement  //restar las comunes a lista 1
                                select new { Element = elementL1 }; //seleccionar el resultado

            //otra forma
            var leftOuterJoin2 = from elementL1 in firstList from elementL2 in secontList.Where
                                 (s => s ==elementL1).DefaultIfEmpty()
                                 select new {Element1 = elementL1, Element2 = elementL2 };

            //outer join - right
            var rightOuterJoin = from elementL2 in secontList
                                join elementL1 in firstList
                                on elementL2 equals elementL1   //join normal hasta aca
                                into tempList    //guardar el inner join en lista temporal
                                from tempElement in tempList.DefaultIfEmpty()   //valida que lista no este vacia
                                where elementL2 != tempElement  //restar las comunes a lista 2
                                select new { Element = elementL2 }; //seleccionar el resultado

            //union
            var unionList = leftOuterJoin.Union(rightOuterJoin);

        }

        public static void SkipTakeLinq()
        {
            var myList = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //skip(omitir)

            var skipTwoFirstValues = myList.Skip(2);

            var skipLastTwoValues = myList.SkipLast(2);

            var skipWhile = myList.SkipWhile(num => num < 5);

            //take(incluye)

            var takeFirstTwoValues = myList.Take(2);
            
            var takeLastTwoValues = myList.TakeLast(2);

            var takeWhileSmallerThan4 = myList.TakeWhile(num => num < 4);
        }
    }
}
