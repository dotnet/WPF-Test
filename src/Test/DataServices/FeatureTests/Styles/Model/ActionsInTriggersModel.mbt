<?xml version="1.0" encoding="utf-16"?>
<IteModel iteVersion="MDEModel_2.1_" sourceTool="MDE" sourceModelPath="" modifiedDatetime="9/21/2005 5:53:59 PM" modelName="ActionsInTriggersModel" label="ActionsInTriggersModel" sourceBinaryPath="" replacedInvalidIdentifiers="true" automated="false" referenceID="4e34da79-1a51-450f-b207-d7a530d9b0d4" comment="" previewMode="false" stateBasedTestGeneration="1" xmlns="http://mbt.ntdev.corp.microsoft.com/mde/MDEModel_2.1_.xsd">
    <StateVariables referenceID="8bc84e16-3a7c-4bec-9a98-65091a1bd903" />
    <ModelParameters referenceID="ffc8b1e6-45d5-42e9-a0d2-5539aa91e2ba">
        <Parameters referenceID="bfdfcb67-19b2-4d51-bf86-e2b8da785bdd">
            <Parameter key_Name="TriggerType" label="TriggerType" key_ActionReferenceID="03a57428-5e92-4ac9-b838-9bb8e0046e38" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="9e125015-6065-4103-8d50-ed4050f24128">
                <ParameterValue key_Name="DataTrigger" label="DataTrigger" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="c884b19e-789b-4ebc-ad21-7d971e2feb8e" />
                <ParameterValue key_Name="MultiDataTrigger" label="MultiDataTrigger" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="d519dde3-6301-414f-9755-916fa376669d" />
            </Parameter>
            <Parameter key_Name="Template" label="Template" key_ActionReferenceID="03a57428-5e92-4ac9-b838-9bb8e0046e38" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="28c64ab1-addf-4202-bb18-35515ced1da2">
                <ParameterValue key_Name="DataTemplate" label="DataTemplate" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="8be157d5-6620-4f0c-97ac-cb310de62f90" />
                <ParameterValue key_Name="HierarchicalDataTemplate" label="HierarchicalDataTemplate" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="46e33af4-f7be-4cd6-ac71-1d9a57d174c9" />
                <ParameterValue key_Name="TableTemplate" label="TableTemplate" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="c2356571-d2b0-4962-ac46-35c092b91c45" />
            </Parameter>
            <Parameter key_Name="Control" label="Control" key_ActionReferenceID="03a57428-5e92-4ac9-b838-9bb8e0046e38" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="d02e1142-0a5b-4ea1-8183-aff788ac13e6">
                <ParameterValue key_Name="ContentControl" label="ContentControl" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="075247ef-99b5-4218-aa44-628cf6824f1a" />
                <ParameterValue key_Name="ItemsControl" label="ItemsControl" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="cbe78398-7e21-48dc-b1e3-c35b400677b0" />
                <ParameterValue key_Name="TreeView" label="TreeView" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="b267a4c7-14cb-4b17-a8da-a10f56d4568a" />
                <ParameterValue key_Name="Table" label="Table" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="8fad1181-860f-4181-9bb4-a4a425d57ea6" />
            </Parameter>
            <Parameter key_Name="Setter_1" label="Setter_1" key_ActionReferenceID="03a57428-5e92-4ac9-b838-9bb8e0046e38" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="1102d8ef-ec2b-4017-a363-799ee22f829c">
                <ParameterValue key_Name="WithSetter" label="WithSetter" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="f9fecd75-82d7-4360-b716-103f6e37670d" />
                <ParameterValue key_Name="WithoutSetter" label="WithoutSetter" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="f2000ed8-4c4d-42da-a057-f5b0d76dac54" />
            </Parameter>
        </Parameters>
        <ParameterCombinationRules seed="1" referenceID="143663eb-f5c8-4f71-b07e-8157219fa73b">
            <ParameterCluster key_Name="CombinationGroup# 0" label="CombinationGroup# 0" comment="" combinatoryType="0" include="true" combinatoryOrder="0" referenceID="4f45a07d-1693-45bd-b6fd-f93f0e07b8ae">
                <ParameterClusterElement key_ParameterReferenceID="9e125015-6065-4103-8d50-ed4050f24128" key_ModelReferenceID="" referenceID="71caa5bb-422e-425b-93a3-0965d89596cc" />
                <ParameterClusterElement key_ParameterReferenceID="28c64ab1-addf-4202-bb18-35515ced1da2" key_ModelReferenceID="" referenceID="3ba7062d-1a6f-4fe1-93b2-343c29a7e666" />
                <ParameterClusterElement key_ParameterReferenceID="d02e1142-0a5b-4ea1-8183-aff788ac13e6" key_ModelReferenceID="" referenceID="7b8e0ada-cf20-4d06-a9e3-4eb84b847551" />
            </ParameterCluster>
            <ParameterDependencyGroup key_Name="TemplateAndControlRestrictions" label="TemplateAndControlRestrictions" comment="" include="true" referenceID="2d121869-ca76-471d-9e6d-13f2466885ff">
                <ParameterDependencyElement criteria="0" referenceID="29b868f3-8379-4263-add4-4f5e4e1007b4">
                    <ParameterDependencyCondition referenceID="99df7a80-623a-44b7-bd8e-dce2005720e3">
                        <ParameterDependencyConditionValue key_ParameterReferenceID="28c64ab1-addf-4202-bb18-35515ced1da2" key_ParameterValueReferenceID="8be157d5-6620-4f0c-97ac-cb310de62f90" key_ModelReferenceID="" referenceID="e47490c2-5b4b-4764-a3c1-c51e33048062" />
                    </ParameterDependencyCondition>
                    <ParameterDependencyTerm referenceID="488687d1-83a9-4f1d-9d80-6ff7939f52eb">
                        <ParameterDependencyTermValue key_ParameterReferenceID="d02e1142-0a5b-4ea1-8183-aff788ac13e6" key_ParameterValueReferenceID="b267a4c7-14cb-4b17-a8da-a10f56d4568a" key_ModelReferenceID="" referenceID="edfd0b2d-2691-4860-b84d-a884afc43e35" />
                    </ParameterDependencyTerm>
                </ParameterDependencyElement>
                <ParameterDependencyElement criteria="0" referenceID="56c11b9e-fd38-4292-9e99-dd08d6b97eca">
                    <ParameterDependencyCondition referenceID="f28e69d1-cd83-4f9a-93ee-c45cb624c0ab">
                        <ParameterDependencyConditionValue key_ParameterReferenceID="28c64ab1-addf-4202-bb18-35515ced1da2" key_ParameterValueReferenceID="8be157d5-6620-4f0c-97ac-cb310de62f90" key_ModelReferenceID="" referenceID="e47490c2-5b4b-4764-a3c1-c51e33048062" />
                    </ParameterDependencyCondition>
                    <ParameterDependencyTerm referenceID="c228b7c4-d202-4dab-bae5-004f12225675">
                        <ParameterDependencyTermValue key_ParameterReferenceID="d02e1142-0a5b-4ea1-8183-aff788ac13e6" key_ParameterValueReferenceID="8fad1181-860f-4181-9bb4-a4a425d57ea6" key_ModelReferenceID="" referenceID="03164629-2c30-4ddf-813f-ec5cb2b7283a" />
                    </ParameterDependencyTerm>
                </ParameterDependencyElement>
                <ParameterDependencyElement criteria="0" referenceID="e66011fd-622d-4dc4-bff2-56760ace067a">
                    <ParameterDependencyCondition referenceID="0fd7cec9-3c42-47fb-944d-67210afa7a0b">
                        <ParameterDependencyConditionValue key_ParameterReferenceID="28c64ab1-addf-4202-bb18-35515ced1da2" key_ParameterValueReferenceID="46e33af4-f7be-4cd6-ac71-1d9a57d174c9" key_ModelReferenceID="" referenceID="e2a58bd6-e192-4ec8-a796-6e1bbd27864e" />
                    </ParameterDependencyCondition>
                    <ParameterDependencyTerm referenceID="3c2bc8af-3261-47ca-a99b-f69119c71dec">
                        <ParameterDependencyTermValue key_ParameterReferenceID="d02e1142-0a5b-4ea1-8183-aff788ac13e6" key_ParameterValueReferenceID="075247ef-99b5-4218-aa44-628cf6824f1a" key_ModelReferenceID="" referenceID="e94fc53d-3fa6-4ef9-b0d5-b732f109b6cf" />
                    </ParameterDependencyTerm>
                </ParameterDependencyElement>
                <ParameterDependencyElement criteria="0" referenceID="4fd1bf9c-69e6-46ba-b9af-41fb469bdcea">
                    <ParameterDependencyCondition referenceID="65e294dd-1e20-4d03-92d4-104639ea0e53">
                        <ParameterDependencyConditionValue key_ParameterReferenceID="28c64ab1-addf-4202-bb18-35515ced1da2" key_ParameterValueReferenceID="46e33af4-f7be-4cd6-ac71-1d9a57d174c9" key_ModelReferenceID="" referenceID="e2a58bd6-e192-4ec8-a796-6e1bbd27864e" />
                    </ParameterDependencyCondition>
                    <ParameterDependencyTerm referenceID="73f77851-6329-425a-ba03-e2a5d04d9fa4">
                        <ParameterDependencyTermValue key_ParameterReferenceID="d02e1142-0a5b-4ea1-8183-aff788ac13e6" key_ParameterValueReferenceID="cbe78398-7e21-48dc-b1e3-c35b400677b0" key_ModelReferenceID="" referenceID="4d33503c-5784-47b4-a5dd-133edff15001" />
                    </ParameterDependencyTerm>
                </ParameterDependencyElement>
                <ParameterDependencyElement criteria="0" referenceID="86d32946-bf0d-4e48-abc5-2e0d1bb7a960">
                    <ParameterDependencyCondition referenceID="181a0a00-01ab-4cd0-af6d-bfb3c1b30bd6">
                        <ParameterDependencyConditionValue key_ParameterReferenceID="28c64ab1-addf-4202-bb18-35515ced1da2" key_ParameterValueReferenceID="46e33af4-f7be-4cd6-ac71-1d9a57d174c9" key_ModelReferenceID="" referenceID="e2a58bd6-e192-4ec8-a796-6e1bbd27864e" />
                    </ParameterDependencyCondition>
                    <ParameterDependencyTerm referenceID="7e897973-94c2-4bb0-8a31-1555082e9550">
                        <ParameterDependencyTermValue key_ParameterReferenceID="d02e1142-0a5b-4ea1-8183-aff788ac13e6" key_ParameterValueReferenceID="8fad1181-860f-4181-9bb4-a4a425d57ea6" key_ModelReferenceID="" referenceID="4fb043ce-f795-4457-a6c6-efe2dcc00f14" />
                    </ParameterDependencyTerm>
                </ParameterDependencyElement>
                <ParameterDependencyElement criteria="0" referenceID="55a7ca2a-6ed1-4c27-92a5-c232606461d2">
                    <ParameterDependencyCondition referenceID="6b877a9a-9bbc-4124-b5c3-9e80ea9cd784">
                        <ParameterDependencyConditionValue key_ParameterReferenceID="28c64ab1-addf-4202-bb18-35515ced1da2" key_ParameterValueReferenceID="c2356571-d2b0-4962-ac46-35c092b91c45" key_ModelReferenceID="" referenceID="ce25f111-7c48-4182-855f-692caf642231" />
                    </ParameterDependencyCondition>
                    <ParameterDependencyTerm referenceID="5bed880d-25e5-405d-b8af-4554d97c7b44">
                        <ParameterDependencyTermValue key_ParameterReferenceID="d02e1142-0a5b-4ea1-8183-aff788ac13e6" key_ParameterValueReferenceID="075247ef-99b5-4218-aa44-628cf6824f1a" key_ModelReferenceID="" referenceID="e6fb8df5-fdbb-464d-ab3b-0fcdabdd580d" />
                    </ParameterDependencyTerm>
                </ParameterDependencyElement>
                <ParameterDependencyElement criteria="0" referenceID="d6d38806-80f1-43d3-9a82-581b7d341f1c">
                    <ParameterDependencyCondition referenceID="e6ac9a3b-c672-40c0-9402-849bb7c57c17">
                        <ParameterDependencyConditionValue key_ParameterReferenceID="28c64ab1-addf-4202-bb18-35515ced1da2" key_ParameterValueReferenceID="c2356571-d2b0-4962-ac46-35c092b91c45" key_ModelReferenceID="" referenceID="ce25f111-7c48-4182-855f-692caf642231" />
                    </ParameterDependencyCondition>
                    <ParameterDependencyTerm referenceID="0ca81eb4-05c8-48d3-a9ea-19959e651960">
                        <ParameterDependencyTermValue key_ParameterReferenceID="d02e1142-0a5b-4ea1-8183-aff788ac13e6" key_ParameterValueReferenceID="cbe78398-7e21-48dc-b1e3-c35b400677b0" key_ModelReferenceID="" referenceID="437b8cfa-73b7-40a5-baa4-c62c5832e404" />
                    </ParameterDependencyTerm>
                </ParameterDependencyElement>
                <ParameterDependencyElement criteria="0" referenceID="19a2efdf-a6ac-45f7-829e-c12f429448c5">
                    <ParameterDependencyCondition referenceID="b69245fa-ed05-4af5-a01a-c99eb61db072">
                        <ParameterDependencyConditionValue key_ParameterReferenceID="28c64ab1-addf-4202-bb18-35515ced1da2" key_ParameterValueReferenceID="c2356571-d2b0-4962-ac46-35c092b91c45" key_ModelReferenceID="" referenceID="ce25f111-7c48-4182-855f-692caf642231" />
                    </ParameterDependencyCondition>
                    <ParameterDependencyTerm referenceID="58121424-683a-4920-8fde-0a5a2dcd02ba">
                        <ParameterDependencyTermValue key_ParameterReferenceID="d02e1142-0a5b-4ea1-8183-aff788ac13e6" key_ParameterValueReferenceID="b267a4c7-14cb-4b17-a8da-a10f56d4568a" key_ModelReferenceID="" referenceID="82387edf-7076-4278-aaf7-0d57483b8040" />
                    </ParameterDependencyTerm>
                </ParameterDependencyElement>
            </ParameterDependencyGroup>
        </ParameterCombinationRules>
    </ModelParameters>
    <Actions referenceID="1d64463a-27bd-4386-ba46-21c526855a8f">
        <Action key_Name="RunAction" label="RunAction" comment="" weight="1" disabled="false" defaultClusterReferenceID="" uiPersistentID="" uiPattern="" uiMethod="" automated="false" referenceID="03a57428-5e92-4ac9-b838-9bb8e0046e38">
            <ActionParameters referenceID="b15f1e7e-4688-44b5-bc31-2c5afcb12dcc">
                <ActionParameter key_ActionParameterReferenceID="9e125015-6065-4103-8d50-ed4050f24128" referenceID="dcc7d1c4-c683-4ade-8e5a-0c975d7dfb02" />
                <ActionParameter key_ActionParameterReferenceID="28c64ab1-addf-4202-bb18-35515ced1da2" referenceID="f600add5-8346-49e2-8c06-383ee2f14cdc" />
                <ActionParameter key_ActionParameterReferenceID="d02e1142-0a5b-4ea1-8183-aff788ac13e6" referenceID="06c3c282-9d9e-4deb-a4ab-c4794305f8cc" />
                <ActionParameter key_ActionParameterReferenceID="1102d8ef-ec2b-4017-a363-799ee22f829c" referenceID="418204e8-a46a-4945-bc69-508d2ebe38d4" />
            </ActionParameters>
        </Action>
    </Actions>
    <TransitionRules referenceID="c7433101-6ca2-46d0-a8a0-0e68de1891a8">
    </TransitionRules>
    <EntryPoints seed="1" referenceID="35f7fcd5-d360-40df-a84f-9ef25f1692bf" />
    <AssertionRules referenceID="dc30f0f7-8c3a-4386-b285-90eabb48e841" />
    <ModelInfo overview="" constructionInfo="" referenceID="43f1a7a5-8da6-4ecb-bc1c-8a735b2568b1" />
    <ModelReferences referenceID="65f6580c-92b2-4898-b676-78c35cd40db8" />
    <ModelLinkRules referenceID="17e56533-20a6-42ab-a80f-d54681fcbe06" />
    <TestQueries referenceID="97fb7933-c8f8-44f5-92ef-68f6581df6dc">
        <TestQuery key_Name="ActionsInTriggersTestCases" label="ActionsInTriggersTestCases" testOutputFilePathName="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-16&quot;?&gt;&#xD;&#xA;&lt;StandAloneLocation xmlns:xsd=&quot;http://www.w3.org/2001/XMLSchema&quot; xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot;&gt;&#xD;&#xA;  &lt;ModelPathName&gt;E:\nt2\testsrc\windowstestdata\redist\client\wcptests\ConnectedData\Styles\ActionsInTriggersModel.mbt&lt;/ModelPathName&gt;&#xD;&#xA;  &lt;TestCaseFileName&gt;E:\nt2\testsrc\windowstestdata\redist\client\wcptests\ConnectedData\Styles\ActionsInTriggersTestCases.xtc&lt;/TestCaseFileName&gt;&#xD;&#xA;&lt;/StandAloneLocation&gt;" comment="" isStateless="true" referenceID="51088646-181c-4268-84f1-e5b680c30a1e" maxTestCases="0" applyFilters="true" testOutputLocationType="Microsoft.Ite.StandAloneInterface.StandAloneLocation,Microsoft.Ite.StandAloneTcmInterface, Version=2.1.2005.0, Culture=neutral, PublicKeyToken=null~" externalDataXml="" externalDataType="" disabled="false">
            <TestPattern seed="1" referenceID="21dcec09-b1ef-45c3-ad6a-dd7e23eba749">
                <TestPatternElement testPatternElementType="0" modelReferenceID="4e34da79-1a51-450f-b207-d7a530d9b0d4" referenceID="77b48c7a-a8b7-441f-bcf1-7ed2775fc8f8">
                    <ActionTestPatternElement actionReferenceID="03a57428-5e92-4ac9-b838-9bb8e0046e38" referenceID="dccd0882-08aa-4f66-929a-3dd0ee67edbd">
                        <ParameterTestPatternElement key_ParameterReferenceID="9e125015-6065-4103-8d50-ed4050f24128" parameterValueReferenceID="" lowWeight="0" highWeight="0" validFilter="0" automatedFilter="0" bucketFilter="" referenceID="3db346fe-3a51-4745-9ee9-024ffedaf2f8" />
                        <ParameterTestPatternElement key_ParameterReferenceID="28c64ab1-addf-4202-bb18-35515ced1da2" parameterValueReferenceID="" lowWeight="0" highWeight="0" validFilter="0" automatedFilter="0" bucketFilter="" referenceID="70328561-d5da-4c93-90db-acc09d904506" />
                        <ParameterTestPatternElement key_ParameterReferenceID="d02e1142-0a5b-4ea1-8183-aff788ac13e6" parameterValueReferenceID="" lowWeight="0" highWeight="0" validFilter="0" automatedFilter="0" bucketFilter="" referenceID="319265ba-50e8-44f0-af05-2dcbf5ac4721" />
                    </ActionTestPatternElement>
                </TestPatternElement>
            </TestPattern>
        </TestQuery>
    </TestQueries>
    <TestFilters referenceID="5afe052b-fc4f-426f-90f9-454acb3b9e8a" />
    <CustomData referenceID="90d70d90-0c4a-4d8c-94b3-73e5136192b1" />
</IteModel>