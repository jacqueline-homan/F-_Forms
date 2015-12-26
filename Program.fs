open System
open System.IO
open System.Net
open System.Windows
open System.Windows.Forms

///Fetching a web page
let form = new Form(Visible = true, TopMost = true, Text = "Welcome to F#")
let textB = new RichTextBox(Dock = DockStyle.Fill, Text = "Here is some initial text")
form.Controls.Add textB
let http (url : string) =
    let req = System.Net.WebRequest.Create(url)
    let resp = req.GetResponse()
    let stream = resp.GetResponseStream()
    let reader = new StreamReader(stream)
    let html = reader.ReadToEnd()
    resp.Close()
    html
///Illustrating mutability by assigning a new value
//textB.Text <- "http://www.astralar.com/the-team/" 

///Setting the Value of a Property dynamically using obj.Propery <- value 
let form2 = new Form()
let textC = new RichTextBox(Dock = DockStyle.Fill)
let req2 = WebRequest.Create("http://www.astralar.com/the-team/")
let resp2 = req2.GetResponse()
let stream2 = resp2.GetResponseStream()
let reader2 = new StreamReader(stream2)
let html = reader2.ReadToEnd()
form2.Visible <- true
form2.TopMost <- true
form2.Text <- "MOAR F#"
form2.Controls.Add(textC)
//This time, we'll show all the HTML elements
textC.Text <- html 

Application.Run(form)



[<EntryPoint>]
let main argv = 
    printfn "Press Enter to exit" 
    let user = Console.ReadKey()
    0 // return an integer exit code

