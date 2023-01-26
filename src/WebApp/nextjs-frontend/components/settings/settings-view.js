import style from "../settings/settings.module.css"

const SettingsView = () => {

    return(
      <div className={style.container}>
        <div>
            <h1>Settings</h1>
        </div>
          <div className={style.header}>
              <h5>Personal info</h5>
              <p>Update your personal data here</p>
          </div>
          <div className={style.main}>
              <div className="input-group" style={{paddingTop:"2rem"}}>
                  <span className="input-group-text">First and last name</span>
                  <input type="text" aria-label="First name" placeholder="John" className="form-control"/>
                  <input type="text" aria-label="Last name" placeholder="Doe" className="form-control"/>
              </div>
              <div className="input-group flex-nowrap" style={{paddingTop:"2rem", paddingBottom: "1rem", borderBottom: "1px solid #D0D5DD"}}>
                  <span className="input-group-text" id="addon-wrapping">email@address.com</span>
                  <input type="email" className="form-control" placeholder="email" aria-label="email"
                         aria-describedby="addon-wrapping"/>
              </div>
              <div className="input-group" style={{paddingTop:"2rem", paddingBottom: "2rem", borderBottom: "1px solid #D0D5DD"}}>
                  <span className="input-group-text">Biography</span>
                  <textarea className="form-control" aria-label="biography"/>
              </div>
              <div className="input-group flex-nowrap" style={{paddingTop:"1rem", paddingBottom: "1rem"}}>
                  <span className="input-group-text" id="addon-wrapping">Preferred language</span>
                  <input type="email" className="form-control" placeholder="polish" aria-label="language"
                         aria-describedby="addon-wrapping"/>
              </div>
              <div className="input-group flex-nowrap" style={{paddingTop:"1rem", paddingBottom: "1rem"}}>
                  <span className="input-group-text" id="addon-wrapping">Weight (kg)</span>
                  <input type="email" className="form-control" placeholder="88" aria-label="weight"
                         aria-describedby="addon-wrapping"/>
              </div>
              <div className="input-group flex-nowrap" style={{paddingTop:"1rem", paddingBottom: "1rem"}}>
                  <span className="input-group-text" id="addon-wrapping">Height (cm)</span>
                  <input type="email" className="form-control" placeholder="193" aria-label="height"
                         aria-describedby="addon-wrapping"/>
              </div>
              <div className="input-group flex-nowrap" style={{paddingTop:"1rem", paddingBottom: "1rem", borderBottom: "1px solid #D0D5DD"}}>
                  <span className="input-group-text" id="addon-wrapping">Calories intake (kcal)</span>
                  <input type="email" className="form-control" placeholder="3300" aria-label="calories"
                         aria-describedby="addon-wrapping"/>
              </div>
          </div>
          <div className="d-grid gap-2 d-md-flex justify-content-md-end" style={{paddingTop: "2rem"}}>
              <button className="btn btn-light me-md-2" type="button">Cancel</button>
              <button className="btn btn-primary" type="button">Save</button>
          </div>
      </div>
    );
}

export default SettingsView;