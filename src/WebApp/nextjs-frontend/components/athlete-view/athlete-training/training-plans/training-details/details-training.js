import style from "./details-training.module.css";

const DetailsTraining = ({ifDisabled}) => {

    return(
        <div className={style.container}>
            <div style={{paddingLeft:"0rem", width:"43vh"}}>
                <label style={{paddingLeft: "0.5rem"}}><b>Exercise</b></label>
                <div className="input-group mb-3">
                    <input type="text" className="form-control" placeholder="Lat pull-down" aria-label="Username"
                           aria-describedby="basic-addon1" disabled={ifDisabled}/>
                </div>
            </div>
            <div style={{paddingLeft:"2rem", width:"16vh"}}>
                <label style={{paddingLeft: "0.5rem"}}><b>Reps</b></label>
                <div className="input-group mb-3">
                    <input type="number" className="form-control" placeholder="10" aria-label="Username"
                           aria-describedby="basic-addon1" disabled={ifDisabled}/>
                </div>
            </div>
            <div style={{paddingLeft:"2rem", width:"16vh"}}>
                <label style={{paddingLeft: "0.5rem"}}><b>Sets</b></label>
                <div className="input-group mb-3">
                    <input type="number" className="form-control" placeholder="4" aria-label="Username"
                           aria-describedby="basic-addon1" disabled={ifDisabled}/>
                </div>
            </div>
            <div style={{paddingLeft:"2rem", width:"16vh"}}>
                <label style={{paddingLeft: "0.5rem"}}><b>Weight</b></label>
                <div className="input-group mb-3">
                    <input type="number" className="form-control" placeholder="50" aria-label="Username"
                           aria-describedby="basic-addon1" disabled={ifDisabled}/>
                </div>
            </div>
        </div>
    );
}

export default DetailsTraining;