// JScript File
 // Formatear   
  
  function unformat_decimal(id){
       id.value=ParseRemoveFromValue(id.value,'$','.');
       id.select();
 }
 
  function format_decimal(id){
       id.value=ParseAddFromValue(id.value,'$','.');
  }
  
  function format_numeric(id){
       id.value=ParseAddFromValue(id.value,'','.');
  }
  
  function unformat_numeric(id){
       id.value=ParseRemoveFromValue(id.value,'$','.');
       id.select();
 }
 
 // Remove Formato
 function ParseRemoveFromValue(value,DollarSign,GroupingSeparator) {
           
            var newValue = value;
            while(newValue.indexOf(DollarSign) > -1)
		       newValue = newValue.replace(DollarSign, '');
	        while(newValue.indexOf(GroupingSeparator) > -1)
		       newValue = newValue.replace(GroupingSeparator, '');
	       return newValue;
 }
 
 // Agregar Formato    
function ParseAddFromValue(value,DollarSign,GroupingSeparator) {
      var currentValue = value;
      var DecimalSign=',';
      var AutoFormatCurrency='';
      if (AutoFormatCurrency) {
         return value;
      } else {
	      var parseValue = '';
	      var newValue = '';
	      var getDecimal = false;
	      var addNegative = false;
      	
	      if(currentValue.indexOf('-') >= 0) {
		      addNegative = true;
		      currentValue = currentValue.replace('-', '');
	      }
	      if(currentValue != '' && currentValue.indexOf(DecimalSign) >= 0) {
		      parseValue = currentValue.substr(0, currentValue.indexOf(DecimalSign));
		      getDecimal = true;
	      } else {
		      parseValue = currentValue;
		      getDecimal = false;
	      }
	      var rotations = parseInt(parseValue.length / 3);
	      if(parseValue.length % 3 == 0)
		      rotations--;
	      for(var i=0; i<rotations; i++)
		      newValue = GroupingSeparator + parseValue.substr(parseValue.length - ((i + 1) * 3), 3) + newValue;
	      newValue = parseValue.substr(0, parseValue.length - ((rotations) * 3)) + newValue;		
	      if(getDecimal)
		      newValue = newValue + currentValue.substr(currentValue.indexOf(DecimalSign));
	      if(newValue.length > 0) {
		      if(addNegative)
			      newValue = DollarSign + '-' + newValue;
		      else
			      newValue = DollarSign + newValue;
	      }
         
	      return newValue;
	   }
   }
 

function ReturnNumber(value){
            var num;
            num = ParseRemoveFromValue(value,'$','.');
           	num = (! parseFloat(num))?0:parseFloat(num); 
            return num;
      }
function ReturnNumber0(value){
            var num;
           	num = (!parseFloat(num))?0:parseFloat(num); 
            return num;
      }      
      
      
      // Funciones de Declaraciones         
   
        function redondeaAlAlza(x,r) {
            xx = Math.floor(x/r);
            if (xx!=x/r) {xx++}
            return (xx*r);
        }
        
        function redondear(x,r) {
            xx = Math.floor(x/r)
            s=(x/r)-xx;
            s=(xx+Math.round(s))*r;
            return s;
        }
        function redondearUp(x,r) {
            //alert(r);
            if(r==1) return redondear(x,r);  
            if(x>0)return redondear(x,r);
            else return redondear(x,r);
        }
        function redondear_input(txt,r) {
            txt.value=redondearUp(ReturnNumber(txt.value),r);
        }
        