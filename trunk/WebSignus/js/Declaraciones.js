// JScript File
/// Manejo ed Color de Fondo en texto   
        function Resaltar_On(Obj)
        {
            if(Obj != null)
            {
               Obj.originalBgColor = Obj.style.backgroundColor;
               Obj.style.backgroundColor="#DBE7F6";
            }
        }
        function ResaltarD_On(Obj)
        {
            if(Obj != null)
            {
               Obj.originalBgColor = Obj.style.backgroundColor;
               Obj.style.backgroundColor="#cccccc";
            }
        }
        function Resaltar_Off(Obj)
        {
            if(Obj != null)
            {
            Obj.style.backgroundColor = Obj.originalBgColor;
            }
        }
        
// Totalizar renglones
function Totalizar(r1,r2,str,r){
            var Renglon = new Array(r1+r2) ; 
            var ValorBase = new Array(r1+r2) ; 
            var Tarifa = new Array(r1+r2) ; 
            var Objeto = "Repeater1_ctl";
            var Objeto2 = "Repeater2_ctl";
            //var Objeto3 = "Repeater3_ctl";
            
            // Carga de Liq. Privada
            for (i=0;i<r1;i++){
                  s=new String(i+1);
                  if(i<9){
                  ide=Objeto+"0"+s+"_TxtR";
                  isvb=Objeto+"0"+s+"_HdIsVb";
                  ctar=Objeto+"0"+s+"_HdCTAR";
                      if ((document.getElementById(isvb).value=="S")&&(document.getElementById(ctar).value=="S")){
                      ita=Objeto+"0"+s+"_HdTari";
                      ivb=Objeto+"0"+s+"_TxtValBas";
                      }
                  }
		          else{
		           ide=Objeto+s+"_TxtR";
		           isvb=Objeto+s+"_HdIsVb";
		           if ((document.getElementById(isvb).value=="S")&&(document.getElementById(ctar).value=="S")){
                       ita=Objeto+s+"_HdTari";
		               ivb=Objeto+s+"_TxtValBas";
		              }
		           }
                  
                  Renglon[i] = redondearUp(ReturnNumber(document.getElementById(ide).value),r);
                  
                  if ((document.getElementById(isvb).value=="S")&&(document.getElementById(ctar).value=="S")){
                        ValorBase[i] = ReturnNumber(document.getElementById(ivb).value);
                        Tarifa[i]= 0.0;
                        Tarifa[i]=document.getElementById(ita).value.replace(',','.');
                        Renglon[i] =ValorBase[i]*Tarifa[i];
                        Renglon[i]=redondearUp(Renglon[i],r)
                     }   
            } 
            // Carga de Seccion de Pagos
            var j=i;
            for (i=0;i<r2;i++){
                  s=new String(i+1);
                  ide=Objeto2+"0"+s+"_TxtR";
                  Renglon[j] = redondearUp(ReturnNumber(document.getElementById(ide).value),r);
                  j=j+1;
            } 
           //Operaciones
           eval(str);
            // Carga de Liq. Privada
            for (i=0;i<r1;i++){
                  s=new String(i+1);
                  
                  if(i<9)ide=Objeto+"0"+s+"_TxtR";
		          else ide=Objeto+s+"_TxtR";		           

                  document.getElementById(ide).value=Renglon[i];
                  document.getElementById(ide).value=document.getElementById(ide).value.replace('.',',');
                  //alert(document.getElementById(ide).value);
                  format_decimal(document.getElementById(ide));
                  //alert(document.getElementById(ide).value);

            } 
            // Carga de Liq. Privada
            var j=i;
            for (i=0;i<r2;i++){
                  s=new String(i+1);
                  ide=Objeto2+"0"+s+"_TxtR";
                  //alert(ide);
                  document.getElementById(ide).value=Renglon[j];
                  format_decimal(document.getElementById(ide));
                  //alert(Renglon[j]);
                  j=j+1;
            } 
           //alert("Cargue");

}

function tabular(e,obj) { 
  tecla=(document.all) ? e.keyCode : e.which; 
  if(tecla!=13) return; 
  frm=obj.form; 
  for(i=0;i<frm.elements.length;i++)  
    if(frm.elements[i]==obj) {  
      if (i==frm.elements.length-1) i=-1; 
      break } 
  frm.elements[i+1].focus(); 
  return false; 
} 

//Funcion que muestra el div en la posicion del mouse AYUDA
function showdiv(event)
{
	//determina un margen de pixels del div al raton
	margin=0;

	//La variable IE determina si estamos utilizando IE
	var IE = document.all?true:false;

	var tempX = 0;
	var tempY = 0;

	//document.body.clientHeight = devuelve la altura del body
	if(IE)
	{ //para IE
		//event.y|event.clientY = devuelve la posicion en relacion a la parte superior visible del navegador
		//event.screenY = devuelve la posicion del cursor en relaciona la parte superior de la pantalla
		//event.offsetY = devuelve la posicion del mouse en relacion a la posicion superior de la caja donde se ha pulsado
		tempX = event.x
		tempY = event.y
		if(window.pageYOffset){
			tempY=(tempY+window.pageYOffset);
			tempX=(tempX+window.pageXOffset);
		}else{
			tempY=(tempY+Math.max(document.body.scrollTop,document.documentElement.scrollTop));
			tempX=(tempX+Math.max(document.body.scrollLeft,document.documentElement.scrollLeft));
		}
	}else{ //para netscape
		//window.pageYOffset = devuelve el tamaño en pixels de la parte superior no visible (scroll) de la pagina
		document.captureEvents(Event.MOUSEMOVE);
		tempX = event.pageX;
		tempY = event.pageY;
	}

	if (tempX < 0){tempX = 0;}
	if (tempY < 0){tempY = 0;}

	//modificamos el valor del id posicion para indicar la posicion del mouse
	//document.getElementById('posicion').innerHTML="PosX = "+tempX+" | PosY = "+tempY;

	//window.alert(event.pageYOffset+" - "+document.body.pageYOffset+" - "+screen.pageYOffset+" - "+this.pageYOffset+" - "+window.pageYOffset);

	document.getElementById('flotante').style.top = (tempY+margin)+"px";
	document.getElementById('flotante').style.left = (tempX+margin)+"px";
	document.getElementById('flotante').style.display='block';
	return;
}


////////////////////-------------------- LIQUIDACION DE AFORO
function TotalizarAforo(r1,r){
            var Renglon = new Array(r1) ; 
            var ValorBase = new Array(r1) ; 
            var Tarifa = new Array(r1) ; 
            var total = 0;
            var Objeto = "ctl00_SampleContent_DataList1_ctl";
            //01_TxtValBas";
            
            
            // Carga de Liq. Privada
            for (i=0;i<r1-1;i++){
                  s=new String(i+1);
                  if(i<9){
                  //ctl00_SampleContent_DataList1_ctl01_TxtR
                  ide=Objeto+"0"+s+"_TxtR";
                  ctar=Objeto+"0"+s+"_HdCTAR";
                      if (document.getElementById(ctar).value=="S"){
                      ita=Objeto+"0"+s+"_txtTari";
                      ivb=Objeto+"0"+s+"_TxtValBas";
                      }
                  }
		          else{
		           ide=Objeto+s+"_TxtR";
		           if (document.getElementById(ctar).value=="S"){
                       ita=Objeto+s+"_TxtTari";
		               ivb=Objeto+s+"_TxtValBas";
		              }
		           }
                  //alert(ide);
                  //var x=$find(ide);
                  
                  //alert(document.aspnetform.ctl00_SampleContent_DataList1_ctl03_TxtR.value);
                  Renglon[i] = redondearUp(ReturnNumber(document.getElementById(ide).value),r);
                  if (document.getElementById(ctar).value=="S"){
                        ValorBase[i] = ReturnNumber(document.getElementById(ivb).value);
                        //format_decimal(document.getElementById(ivb));
                        Tarifa[i]= 0.0;
                        Tarifa[i]=document.getElementById(ita).value.replace(',','.');
                        Renglon[i]=ValorBase[i]*Tarifa[i];
                        Renglon[i]=redondearUp(Renglon[i],r);
                        total=total+Renglon[i];
                     }   
            } 
            // Carga de Seccion de Pagos
           //Operaciones
//           eval(str);
            // Carga de Liq. Privada
            for (i=0;i<r1-1;i++){
                  s=new String(i+1);
                  if(i<9)ide=Objeto+"0"+s+"_TxtR";
		          else ide=Objeto+s+"_TxtR";		           
                  document.getElementById(ide).value=Renglon[i];
                  format_decimal(document.getElementById(ide));
            } 
                  
                  s=new String(r1);
                  if(i<9)ide=Objeto+"0"+s+"_TxtR";
		          else ide=Objeto+s+"_TxtR";		   
                  document.getElementById(ide).value=total;
                  format_decimal(document.getElementById(ide));


}

////////////////////-------------------- LIQUIDACION DE CORRECCIÓN
function TotalizarCA3(r1,r){
            var Renglon = new Array(r1) ; 
            var ValorBase = new Array(r1) ; 
            var Tarifa = new Array(r1) ; 
            var total = 0;
            var Objeto = "ctl00_SampleContent_DataList1_ctl";
            //01_TxtValBas";
            
            
            // Carga de Liq. Privada
            for (i=0;i<r1-1;i++){
                  s=new String(i+1);
                  if(i<9){
                  //ctl00_SampleContent_DataList1_ctl01_TxtR
                  ide=Objeto+"0"+s+"_TxtR";
                  ctar=Objeto+"0"+s+"_HdCTAR";
                      if (document.getElementById(ctar).value=="S"){
                      ita=Objeto+"0"+s+"_txtTari";
                      ivb=Objeto+"0"+s+"_TxtValBas";
                      }
                  }
		          else{
		           ide=Objeto+s+"_TxtR";
		           if (document.getElementById(ctar).value=="S"){
                       ita=Objeto+s+"_TxtTari";
		               ivb=Objeto+s+"_TxtValBas";
		              }
		           }
                  //alert(ide);
                  //var x=$find(ide);
                  
                  //alert(document.aspnetform.ctl00_SampleContent_DataList1_ctl03_TxtR.value);
                  Renglon[i] = redondearUp(ReturnNumber(document.getElementById(ide).value),r);
                  if (document.getElementById(ctar).value=="S"){
                        ValorBase[i] = ReturnNumber(document.getElementById(ivb).value);
                        //format_decimal(document.getElementById(ivb));
                        Tarifa[i]= 0.0;
                        Tarifa[i]=document.getElementById(ita).value.replace(',','.');
                        Renglon[i]=ValorBase[i]*Tarifa[i];
                        Renglon[i]=redondearUp(Renglon[i],r);
                        total=total+Renglon[i];
                     }   
            } 
            // Carga de Seccion de Pagos
           //Operaciones
//           eval(str);
            // Carga de Liq. Privada
            for (i=0;i<r1-1;i++){
                  s=new String(i+1);
                  if(i<9)ide=Objeto+"0"+s+"_TxtR";
		          else ide=Objeto+s+"_TxtR";		           
                  document.getElementById(ide).value=Renglon[i];
                  format_decimal(document.getElementById(ide));
            } 
                  
                  s=new String(4);
                  if(i<9)ide=Objeto+"0"+s+"_TxtR";
		          else ide=Objeto+s+"_TxtR";		   
                  document.getElementById(ide).value=total;
                  format_decimal(document.getElementById(ide));
                  //alert(total);


}


// Totalizar renglones
function TotalizarCA(r1,r2,str,r){
            var Renglon = new Array(r1+r2) ; 
            var ValorBase = new Array(r1+r2) ; 
            var Tarifa = new Array(r1+r2) ; 
            var Objeto = "ctl00_SampleContent_DataList1_ctl";
            
            var total =0;
            
            // Carga de Liq. Privada
            for (i=0;i<r1;i++){
                  s=new String(i+1);
                  if(i<9){
                  ide=Objeto+"0"+s+"_TxtR";
                  isvb=Objeto+"0"+s+"_HdIsVb";
                  ctar=Objeto+"0"+s+"_HdCTAR";
                      if ((document.getElementById(isvb).value=="S")&&(document.getElementById(ctar).value=="S")){
                      ita=Objeto+"0"+s+"_HdTari";
                      ivb=Objeto+"0"+s+"_TxtValBas";
                      }
                  }
		          else{
		           ide=Objeto+s+"_TxtR";
		           isvb=Objeto+s+"_HdIsVb";
		           if ((document.getElementById(isvb).value=="S")&&(document.getElementById(ctar).value=="S")){
                       ita=Objeto+s+"_HdTari";
		               ivb=Objeto+s+"_TxtValBas";
		              }
		           }
                  //alert(ide);
                  Renglon[i] = redondearUp(ReturnNumber(document.getElementById(ide).value),r);
                  if ((document.getElementById(isvb).value=="S")&&(document.getElementById(ctar).value=="S")){
                        ValorBase[i] = ReturnNumber(document.getElementById(ivb).value);
                        Tarifa[i]= 0.0;
                        Tarifa[i]=document.getElementById(ita).value.replace(',','.');
                        Renglon[i] =ValorBase[i]*Tarifa[i];
                        Renglon[i]=redondearUp(Renglon[i],r)
                        total=total+Renglon[i];
                     }   
            } 
            str="Renglon[3]=total;Renglon[5]=Renglon[3]+Renglon[4];";
            eval(str);
            // Carga de Seccion de Pagos
            var j=i;
            for (i=0;i<r2;i++){
                  s=new String(i+1);
                  ide=Objeto2+"0"+s+"_TxtR";
                  Renglon[j] = redondearUp(ReturnNumber(document.getElementById(ide).value),r);
                  j=j+1;
            } 
           //Operaciones
           
           
            // Carga de Liq. Privada
            for (i=0;i<r1;i++){
                  s=new String(i+1);
                  
                  if(i<9)ide=Objeto+"0"+s+"_TxtR";
		          else ide=Objeto+s+"_TxtR";		           

                  document.getElementById(ide).value=Renglon[i];
                  format_decimal(document.getElementById(ide));

            } 
            // Carga de Liq. Privada
            var j=i;
            for (i=0;i<r2;i++){
                  s=new String(i+1);
                  ide=Objeto2+"0"+s+"_TxtR";
                  //alert(ide);
                  document.getElementById(ide).value=Renglon[j];
                  format_decimal(document.getElementById(ide));
                  //alert(Renglon[j]);
                  j=j+1;
            } 
           //alert("Cargue");

}
