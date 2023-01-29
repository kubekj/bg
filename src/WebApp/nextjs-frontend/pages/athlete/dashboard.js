import { getSession } from "next-auth/react";
import DashboardMain from "../../components/athlete-view/athlete-dashboard/dashboard-main";
import Athlete from "../../components/layouts/Athlete";

const AthleteMainPage = () => {
  return <DashboardMain />;
};

export default AthleteMainPage;

AthleteMainPage.layout = Athlete;
