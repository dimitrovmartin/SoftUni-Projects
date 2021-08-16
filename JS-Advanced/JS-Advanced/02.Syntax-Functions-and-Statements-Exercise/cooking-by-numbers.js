function solve(num, op1, op2, op3, op4, op5){
    num = Number(num);

    function applyOperation(num, op){
        switch (op) {
              case 'chop':
                num /= 2;
                break;
                case 'dice':
                    num = Math.sqrt(num);
                   break;
                  case 'spice':
                    num++;
                   break;
                  case 'bake':
                    num *= 3;
                  break;
                   case 'fillet':
                    num *= 0.8;
                  break;
            
              default:
                   break;
           }

        console.log(num);
        return num;
      }

      num = applyOperation(num, op1);
      num = applyOperation(num, op2);
      num = applyOperation(num, op3);
      num = applyOperation(num, op4);
      num = applyOperation(num, op5);
}

solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet');