# Lab2Csharp

Skapa en konsollaplikation som skall agera som en enkel affär. När programmet körs så ska man få se
någon form av meny där man ska kunna välja att registrera ny kund eller logga in. Därefter ska
ytterligare en meny visas där man ska kunna välja att handla, se kundvagn eller gå till kassan.
Om man väljer att handla ska man få upp minst 3 olika produkter att köpa (t.ex. Korv, Dricka och
Äpple). Man ska se pris för varje produkt och kunna lägga till vara i kundvagn.
Kundvagnen ska visa alla produkter man lagt i den, styckpriset, antalet och totalpriset samt totala
kostnaden för hela kundvagnen. Kundvagnen skall sparas i kund och finnas tillgänglig när man loggar
in.
När man ska Registrera en ny kund ska man ange Namn och lösenord. Dessa ska sparas och namnet
ska inte gå att ändra.
Väljer man Logga In så ska man skriva in namn och lösenord. Om användaren inte finns registrerad
ska programmet skriva ut att kunden inte finns och fråga ifall man vill registrera ny kund. Om
lösenordet inte stämmer så ska programmet skriva ut att lösenordet är fel och låta användaren
försöka igen.
Både kund och produkt ska vara separata klasser med Properties för information och metoder för att
räkna ut totalpris och verifiera lösenord.
I klassen Kund skall det finnas en ToString() som skriver ut Namn, lösenord och kundvagnen på ett
snyggt sätt.

OBS! Extra uppgift som krävs för VG!
Som Extra uppgift ska man på något sätt implementera 3 nivåer av kund (Gold, Silver och Bronze),
dessa ska ha olika mycket rabatt.
Gold: 15% rabatt på hela köpet
Silver: 10% rabatt på hela köpet
Bronze: 5% rabatt på hela köpet
Nivåerna skall implementeras med hjälp av arv av basklassen Kund.
Programmet ska också spara alla registrerade kunder så att de går att använda emellan körningar.
(OBS! Kundvagnar behöver ej sparas) Tips: textfil.
Man ska också kunna välja att se priser i minst 3 olika valutor (två ytterligare förutom SEK).

#Uppgiften bruten till mindre uppgifter: 
// Del 1: Skapa en huvudmeny där man kan registrera ny kund och logga in -switch? cHHECK

//Del 2: Skapa en kund klass med properties namn (kan inte ändras), lösen, Kundvagn 
//(en lista av produkter) CHECK

//Del 3: Skapa en produkt klass med produktnamn, pris perstyck, antal i kundvagn

//Del 4: REgistera ny kund ska vara ett menyval, begär användarnan och lösen och 
//lägg sen användaren i en kundlista, kontorllera att kundnamnet är unikt

//Del 5: Logga in, be om namn och lösen, kontorllera om allt finns och sätmmer,
//om fel lösen ges visa felmeddleande och försök igen

//Del 6: När man loggat in så ska en ny meny visas med följande val: handla, visa
//kundvagn, gå till kassan

//Del 7: Handla, visa minst 3 produkter, låt användaren välja proukter, gör en
//metod som lägger till produkter ochupdaterar antal om samma produkt redan finns

//DEl 8: Visa kundvagn. Skapa en funktion som visar alla produkter i kundvagen,
//styckpris, antal, totalpris, total kostand för allt

//Del 9: Gå till kassan, visa en sammanfattning av kundvagn och totalpriset för allt,
//töm kundvagn efter betalning

//Del 10: skapa en ToString() metod i kund klassen som skriver ut namn, lösen,
//innehållet i kundvagn på snyggt sätt,
//med namn, pris och total kostnad
