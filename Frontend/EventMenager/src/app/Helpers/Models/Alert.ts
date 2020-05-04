import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';
import { ReturnModel } from './ReturnModel';

export class Alert{

    
    private static  _instance : Alert;
    
    private constructor(private _snackBar: MatSnackBar) {}

    static getInstance(snackBar: MatSnackBar) : Alert{
        if(!Alert._instance){
            Alert._instance = new Alert(snackBar)
        }
        return this._instance;
    }

    openTopAlert(object : ReturnModel){
        let config = new MatSnackBarConfig();

        console.log(object);
        if(object.status = 'OK'){
            config.panelClass = 'success-message';
            config.verticalPosition = 'top';
            config.duration= 2500;
        }
        else{
            config.panelClass = 'wrong-message';
            config.verticalPosition = 'top';
            config.duration= 2500;
        }
        this._snackBar.open(object.message, '',config);
        
        
    }

}