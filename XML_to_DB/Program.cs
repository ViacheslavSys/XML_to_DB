using System.Xml.Linq;

namespace XML_to_DB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path;
            Console.WriteLine("Введите путь до XML файла:");//C:\\Users\\Admin\\Desktop\\.net\\orders.xml
            path = Console.ReadLine();
            try
            {
                XDocument xdoc = XDocument.Load(path);
                XElement? orders = xdoc.Element("orders");
                if (orders is not null)
                {
                    // проходим по всем элементам order
                    foreach (XElement order in orders.Elements("order"))
                    {
                        XElement? user = order.Element("user");
                        XElement? fio = user.Element("fio");
                        XElement? email = user.Element("email");
                        XElement? no = order.Element("no");
                        XElement? reg_date = order.Element("reg_date");
                        XElement? sum = order.Element("sum");
                        DateTime dt = (DateTime)reg_date;
                        DateOnly do_reg_data = DateOnly.FromDateTime(dt);
                        using (BdForShopContext db = new BdForShopContext())
                        {
                            Пользователи u = db.Пользователиs.FirstOrDefault(p => p.EmailПользователя == (string)email);
                            if (u == null)
                            {
                                u = new Пользователи { ИмяПользователя = (string)fio, EmailПользователя = (string)email };
                                db.Пользователиs.Add(u);
                                db.SaveChanges();

                            }
                            КорзинаПользователя p = db.КорзинаПользователяs.FirstOrDefault(p => p.IdЗаказа == (int)no);
                            if (p == null)
                            {
                                p = new КорзинаПользователя { IdЗаказа = (int)no, IdПользователя = u.IdПользователя, ДатаЗаказа = do_reg_data, СтоимостьЗаказа = (decimal?)sum };
                                db.КорзинаПользователяs.Add(p);
                                db.SaveChanges();

                            }
                        }
                        foreach (XElement product in order.Elements("product"))
                        {
                            XElement? quantity = product.Element("quantity");
                            XElement? name_product = product.Element("name");
                            XElement? price = product.Element("price");
                            using (BdForShopContext db = new BdForShopContext())
                            {
                                Товары products = db.Товарыs.FirstOrDefault(p => p.НазваниеТовара == (string)name_product);
                                if (products == null)
                                {
                                    products = new Товары { НазваниеТовара = (string)name_product, ЦенаТовара = (decimal)price };
                                    db.Товарыs.Add(products);
                                    db.SaveChanges();

                                }
                                ПокупкиТоваровПользователями bpu = db.ПокупкиТоваровПользователямиs.FirstOrDefault(bp => bp.IdЗаказа == (int)no && bp.IdТовара == products.IdТовара);
                                if (bpu == null)
                                {
                                    bpu = new ПокупкиТоваровПользователями { IdЗаказа = (int)no, IdТовара = products.IdТовара, КоличествоТовара = (int)quantity };
                                    db.ПокупкиТоваровПользователямиs.Add(bpu);
                                    db.SaveChanges();

                                }
                            }
                        }
                        Console.WriteLine("Данные успешно загружены");
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Вы ввели неправильный путь");
            }
            catch(Exception e)
            {
                Console.WriteLine("Что-то пошло не так");
            }       
        }
    }
}
