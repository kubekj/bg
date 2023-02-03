import style from "./exercise-dropdown.module.css"

const ExerciseDropdown = () => {

    return (
        <div className={style.container}>
            <div style={{width:"31vh"}}>
                <label style={{paddingLeft: "0.5rem"}}><b>Select exercise</b></label>
                <div className="input-group mb-3">
                    <select className="form-select" id="inputGroupSelect01">
                        <option selected>Select body part</option>
                        <option value="1">One</option>
                        <option value="2">Two</option>
                        <option value="3">Three</option>
                    </select>
                </div>
            </div>
            <div style={{paddingLeft:"2rem"}}>
                <label style={{paddingLeft: "0.5rem"}}><b>Sets</b></label>
                <div className="input-group mb-3">
                    <input type="number" className="form-control" placeholder="No. of sets" aria-label="Username"
                           aria-describedby="basic-addon1"/>
                </div>
            </div>
            <div style={{paddingLeft:"2rem"}}>
                <label style={{paddingLeft: "0.5rem"}}><b>Reps</b></label>
                <div className="input-group mb-3">
                    <input type="number" className="form-control" placeholder="No. of reps" aria-label="Username"
                           aria-describedby="basic-addon1"/>
                </div>
            </div>
        </div>
    );
}

export default ExerciseDropdown;