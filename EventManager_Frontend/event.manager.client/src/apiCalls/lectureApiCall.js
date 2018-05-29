import axios from "axios/index";
import moment from "moment/moment";

export default function addLecture(state,props){


    if( state.startTime==="" || state.startDate==="" || state.endTime===""|| state.endDate===""){
        window.confirm("Należy wypełnić wszystkie pola!");
    }

    let startTmp = (moment(state.startDate).format("YYYY-MM-DD").toString() + "T" + state.startTime);
    let endTmp =  (moment(state.endDate).format("YYYY-MM-DD").toString() + "T" + state.endTime);

    axios.post('/lecture', {ownerId: 1, eventId: state.eventId, name: state.name, participantNumber: state.participantNumber, startDate: startTmp, endDate: endTmp, description: state.description})
        .then(()=>{
            props.history.push("/ShowEvent/"+state.eventId);
            window.confirm('Wykład został dodany poprawnie!');
        })
        .catch((err)=>{
            console.log(err);
        });
}

