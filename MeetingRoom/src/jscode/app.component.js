"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var AppComponent = (function () {
    function AppComponent() {
        this.flag = false;
        this.daterange = {};
        this.dateArray = [];
        this.timeArray = [];
        // see original project for full list of options
        // can also be setup using the config service to apply to multiple pickers
        this.options = {
            locale: { format: 'YYYY-MMMM-DD' },
            minDate: new Date(),
            dateLimit: {
                days: 30,
            }
        };
    }
    AppComponent.prototype.selectedDate = function (value) {
        this.flag = true;
        this.daterange.start = value.start;
        this.daterange.end = value.end;
        this.daterange.label = value.label;
        console.log(value);
        console.log(value.end._d.toLocaleDateString());
        var st = new Date(value.start._d.toLocaleDateString());
        var ed = new Date(value.end._d.toLocaleDateString());
        var i = 0;
        while (i < 31) {
            this.dateArray[i] = new Date(st).toString().slice(4, 15);
            st.setDate(st.getDate() + 1);
            i = i + 1;
        }
        for (var j = 0; j < 48; j++) {
            var date = new Date();
            date.setHours(0, 0, 0);
            date.setMinutes(j * 30);
            this.timeArray[j] = date.toTimeString().slice(0, 5);
        }
    };
    AppComponent.prototype.func = function (item) {
        console.log(item);
        if (item.target.bgColor == "red")
            item.target.bgColor = "white";
        else
            item.target.bgColor = "red";
    };
    return AppComponent;
}());
AppComponent = __decorate([
    core_1.Component({
        moduleId: module.id.replace('jscode', 'app'),
        selector: 'my-app',
        templateUrl: 'app.component.html'
    })
], AppComponent);
exports.AppComponent = AppComponent;
//# sourceMappingURL=app.component.js.map