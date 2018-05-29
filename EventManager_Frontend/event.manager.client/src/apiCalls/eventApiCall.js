import axios from "axios/index";
import moment from 'moment';

export function addEvent(state, props){
    if( state.startTime==="" || state.startDate==="" || state.endTime===""|| state.endDate===""){
        window.confirm("Należy wypełnić wszystkie pola!");
    }

    let startTmp = (moment(state.startDate).format("YYYY-MM-DD").toString() + "T" + state.startTime);
    let endTmp =  (moment(state.endDate).format("YYYY-MM-DD").toString() + "T" + state.endTime);

    axios.post('/event', {firstName: state.userName, surname: state.userSurname, name: state.name, participantNumber: state.participantNumber, startDate:startTmp, endDate: endTmp, description: state.description })
        .then(()=>{
            props.history.push("/ShowEvents");
            window.confirm('Wydarzenie zostało utworzone poprawnie!');
        })
        .catch((err)=>{
            console.log(err);
        });
}