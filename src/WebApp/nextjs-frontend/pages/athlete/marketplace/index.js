import MarketplaceMainView from "../../../components/athlete/marketplace/marketplace-main-view";
import Athlete from "../../../components/layouts/Athlete";
import {getSession} from "next-auth/react";
import fetcher from "../../../lib/rest-api";

export async function getServerSideProps(context) {
  const session = await getSession({ req: context.req });

  if (!session) {
    return {
      redirect: {
        destination: "/auth/login",
        permanent: false,
      },
    };
  }

  const options = {
    headers: {
      Authorization: `Bearer ${session.jwt}`,
    },
  };

  const plans = await fetcher("training-plans", options);

  return {
    props: { jwt: session.jwt, plans: plans },
  };
}

const AthleteMarketplace = ({ jwt, plans }) => {
  return <MarketplaceMainView plans={plans} />;
};

export default AthleteMarketplace;

AthleteMarketplace.layout = Athlete;
