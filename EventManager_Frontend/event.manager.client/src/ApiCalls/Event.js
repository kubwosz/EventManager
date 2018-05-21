import axios from "axios/index";

export default function addEvent(state){
    axios.post('/event', {ownerId: 1, name: state.name, participantNumber: state.participantNumber, startDate: state.startDate, endDate: state.endDate, description: state.description })
        .then(()=>{
        })
        .catch((err)=>{
            console.log(err);
        });
}