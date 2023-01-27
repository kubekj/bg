import style from "./training-plans-view.module.css";
import Link from "next/link";
import Button from "../../../reusable-comps/button";
import React from "react";
import Image from "next/image";


const TrainingPlansView = () => {

    const sampleData = [
        {
            id: 1,
            firstName: "John",
            lastName: "Doe",
            email: "john.doe@gmail.com",
            duration: "2 weeks",
            isActive: true,
            purchaseDate: "Jan 4, 2022",
            type: "Full-body",
            author: "Olivia Rye"
        },
        {
            id: 2,
            firstName: "John",
            lastName: "Smith",
            email: "john.doe@gmail.com",
            duration: "2 weeks",
            isActive: true,
            purchaseDate: "Jun 14, 2022",
            type: "Full-body",
            author: "Olivia Rye"
        },
        {
            id: 3,
            firstName: "John",
            lastName: "Doe",
            email: "john.doe@gmail.com",
            duration: "4 weeks",
            isActive: false,
            purchaseDate: "Jan 4, 2022",
            type: "Full-body",
            author: "Olivia Rye"
        },
        {
            id: 4,
            firstName: "Jane",
            lastName: "Doe",
            email: "john.doe@gmail.com",
            duration: "3 weeks",
            isActive: false,
            purchaseDate: "Jan 4, 2022",
            type: "Full-body",
            author: "Me"
        },
    ];

    return(
        <div className={style.container}>
            <div className={style.header}>
                <h2>Training plans</h2>
                <p>Manage all your training plans here.</p>
            </div>
            <div className={style.tableContainer}>
                <div className={style.header}>
                    <div className={style.info}>
                        <div>
                            <h4><b>Plan</b></h4>
                        </div>
                        <div style={{marginLeft: "73rem", marginBottom:"0.75rem"}}>
                            <Link href="/add-new-training">
                                <Button iconSrc="/thumbnails/add-outline.svg" text="Add training"
                                        backgroundColorValue="#8098F9"
                                        borderValue="none"
                                        isHoveringColor="#C7D7FE"
                                        extraStyleType="color"
                                        extraStyleValue="white"
                                />
                            </Link>
                        </div>
                    </div>
                </div>
                <div>
                    <table className={style.tableOfTrainings}>
                        <thead className={style.tHead}>
                        <tr>
                            <th className={style.thRegular}>Author</th>
                            <th className={style.thRegular}>Status</th>
                            <th className={style.thRegular}>Duration</th>
                            <th className={style.thRegular}>Purchase date</th>
                            <th className={style.thRegular}>Type</th>
                            <th className={style.thRegular}>Author</th>
                            <th className={style.thRegular}>Actions</th>
                        </tr>
                        </thead>
                        <tbody className={style.tBody}>
                        {
                            sampleData.map(training => {
                                return(

                                    <tr key={training.id}>
                                        <td style={{width:"30%",borderBottom: "1px solid #D0D5DD", paddingLeft:"2rem"}}>
                                            <Link href="/training-details-more" style={{textDecoration:"none"}}>
                                            <div className={style.bottomSection}>
                                                <div className={style.userInfo}>
                                                    <Image className={style.avatar} src="/avatar-svgrepo-com.svg" alt="dadas" width={30} height={30} />
                                                    <div>
                                                        <h5>{training.firstName} {training.lastName}</h5>
                                                        <p>{training.email}</p>
                                                    </div>
                                                </div>
                                            </div>
                                            </Link>
                                        </td>
                                        <td className={style.tdRegular}>
                                            <div className={style.infoProgress}
                                                 style={{backgroundColor: sampleData.map(a => a.isActive) ? "#ECFDF3" : "#FEF3F2",
                                                     color: sampleData.map(a => a.isActive) ? "#027A48" : "#B42318"
                                                 }}
                                            >
                                                Status
                                            </div>
                                        </td>
                                        <td className={style.tdRegular}>{training.duration}</td>
                                        <td className={style.tdRegular}>{training.purchaseDate}</td>
                                        <td className={style.tdRegular}>{training.type}</td>
                                        <td className={style.tdRegular}>{training.author}</td>
                                        <td className={style.tdRegular}>
                                            <div>
                                                <Button iconSrc="/thumbnails/modify.svg" extraStyleType="marginLeft" extraStyleValue="2rem"
                                                        backgroundColorValue="white"
                                                        isHoveringColor="#D0D5DD"
                                                        borderValue="none"
                                                />
                                                <Button iconSrc="/thumbnails/trash-bin-outline.svg" extraStyleType="marginLeft" extraStyleValue="2rem"
                                                        backgroundColorValue="white"
                                                        isHoveringColor="#D0D5DD"
                                                        borderValue="none"
                                                />
                                            </div>
                                        </td>
                                    </tr>

                                );
                            })
                        }
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    );
}

export default TrainingPlansView;