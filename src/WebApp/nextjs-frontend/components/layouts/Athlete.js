import React from "react";
import Sidebar from "../reusable/sidebar";
import style from "../../styles/athlete-main-page.module.css";

function Athlete({ user, loading = false, children }) {
  return (
    <>
      <div className={style.container}>
        <div style={{ borderRight: "1px solid #D0D5DD", width: "325px" }}>
          <Sidebar />
        </div>
        {children}
      </div>
    </>
  );
}

export default Athlete;
