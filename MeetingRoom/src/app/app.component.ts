import { Component } from '@angular/core';

@Component({
    moduleId: module.id.replace('jscode', 'app'),
    selector: 'my-app',
    templateUrl: 'app.component.html'
})

export class AppComponent {
    public flag:boolean=false;
    public daterange: any = {};
  public dateArray:any[]=[];
  public timeArray:any[]=[];
    // see original project for full list of options
    // can also be setup using the config service to apply to multiple pickers
    public options: any = {

        locale: { format: 'YYYY-MMMM-DD' },
        minDate: new Date(),
        dateLimit: {
            days: 30,
        }

    };

    public selectedDate(value: any) {
        this.flag=true;
        this.daterange.start = value.start;
        this.daterange.end = value.end;
        this.daterange.label = value.label;
        console.log(value);
        console.log(value.end._d.toLocaleDateString());
        let st = new Date(value.start._d.toLocaleDateString());
        let ed =new Date(value.end._d.toLocaleDateString());
        let i=0;
        while (i<31) {
            this.dateArray[i]=new Date(st).toString().slice(4,15);
            st.setDate(st.getDate() + 1);
            i=i+1;
        }

        for (var j = 0; j < 48; j++) {
            var date = new Date();
            date.setHours(0, 0, 0);
            date.setMinutes(j * 30);
            this.timeArray[j] =  date.toTimeString().slice(0, 5);

        }


    }

    public func(item:any){
        console.log(item);
        if(item.target.bgColor=="red")
            item.target.bgColor="white";
        else
            item.target.bgColor="red";
    }

}
