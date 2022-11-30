
const SignInContent = () => {
    return(
        <div>
            <div className="mb-3">
                <label htmlFor="formGroupExampleInput" className="form-label">Name</label>
                <input type="text" className="form-control" id="formGroupExampleInput"
                       placeholder="f.e. John"/>
            </div>
            <div className="mb-3">
                <label htmlFor="formGroupExampleInput" className="form-label">Surname</label>
                <input type="text" className="form-control" id="formGroupExampleInput"
                       placeholder="f.e. Doe"/>
            </div>
            <div className="mb-3">
                <label htmlFor="formGroupExampleInput" className="form-label">Email</label>
                <input type="email" className="form-control" id="formGroupExampleInput"
                       placeholder="f.e. john.doe@gmail.com"/>
            </div>
            <div className="mb-3">
                <label htmlFor="formGroupExampleInput2" className="form-label">Password</label>
                <input type="password" className="form-control" id="formGroupExampleInput2"
                       placeholder="******"/>
            </div>
        </div>
    );
}

export default SignInContent;